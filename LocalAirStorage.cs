using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// LocalAirStorage class.
    /// </summary>
    public class LocalAirStorage : IAirStorage
    {
        private readonly ConcurrentDictionary<long, byte[]> _store;
        private readonly ConcurrentDictionary<long, Semaphore> _locks;
        private readonly object _syncLock;
        private readonly Task _emptyTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalAirStorage" /> class.
        /// </summary>
        public LocalAirStorage()
        {
            _store = new ConcurrentDictionary<long, byte[]>();
            _locks = new ConcurrentDictionary<long, Semaphore>();
            _syncLock = new object();
            _emptyTask = new Task(() => { });
            _emptyTask.Start();
            _emptyTask.Wait();
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Task AddAsync(long key, byte[] value)
        {
            if (!_store.TryAdd(key, value))
            {
                throw new Exception();
            }

            return _emptyTask;
        }

        /// <summary>
        /// Sets the async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Task SetAsync(long key, byte[] value)
        {
            _store[key] = value;
            return _emptyTask;
        }

        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        /// string&gt;();
        public Task<bool> ContainsAsync(long key)
        {
            return Task.FromResult(_store.ContainsKey(key));
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(long key)
        {
            byte[] value;
            return Task.FromResult(_store.TryRemove(key, out value));
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Task<byte[]> TryGetAsync(long key)
        {
            byte[] value;
            _store.TryGetValue(key, out value);
            return Task.FromResult(value);
        }

        /// <summary>
        /// Gets the lock async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns on completion.</returns>
        public Task GetLockAsync(long key)
        {
            lock (_syncLock)
            {
                Semaphore nodeSyncLock;
                if (!_locks.TryGetValue(key, out nodeSyncLock))
                {
                    nodeSyncLock = new Semaphore(1, 1);
                    _locks[key] = nodeSyncLock;
                }

                nodeSyncLock.WaitOne();
            }

            return Task.Factory.StartNew(() => { });
        }

        /// <summary>
        /// Releases the lock async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Task ReleaseLockAsync(long key)
        {
            var nodeSyncLock = _locks[key];
            nodeSyncLock.Release();
            return _emptyTask;
        }
    }
}
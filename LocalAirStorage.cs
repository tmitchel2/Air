using System.Collections.Generic;
using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// LocalAirStorage class.
    /// </summary>
    public class LocalAirStorage : IAirStorage
    {
        private readonly Dictionary<long, byte[]> _store;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalAirStorage" /> class.
        /// </summary>
        public LocalAirStorage()
        {
            _store = new Dictionary<long, byte[]>();
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Task AddAsync(long key, byte[] value)
        {
            return Task.Factory.StartNew(() => _store.Add(key, value));
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
            return Task<bool>.Factory.StartNew(() => _store.ContainsKey(key));
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(long key)
        {
            return Task<bool>.Factory.StartNew(() => _store.Remove(key));
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Task<byte[]> TryGetAsync(long key)
        {
            return Task<byte[]>.Factory.StartNew(() =>
                {
                    byte[] value;
                    _store.TryGetValue(key, out value);
                    return value;
                });
        }
    }
}
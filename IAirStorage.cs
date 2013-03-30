using System;
using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// IAirStorage interface
    /// </summary>
    public interface IAirStorage
    {
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task AddAsync(long key, byte[] value);

        /// <summary>
        /// Sets the async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task SetAsync(long key, byte[] value);

        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> ContainsAsync(long key);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(long key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<byte[]> TryGetAsync(long key);

        /// <summary>
        /// Gets the lock async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task GetLockAsync(long key);

        /// <summary>
        /// Releases the lock async.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task ReleaseLockAsync(long key);
    }
}
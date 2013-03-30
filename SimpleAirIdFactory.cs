using System.Threading;

namespace Air
{
    /// <summary>
    /// SimpleAirIdFactory class.
    /// </summary>
    public class SimpleAirIdFactory : IAirIdFactory
    {
        private long _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAirIdFactory" /> class.
        /// </summary>
        /// <param name="startId">The start id.</param>
        public SimpleAirIdFactory(long startId)
        {
            _id = startId;
        }

        /// <summary>
        /// Gets the next id.
        /// </summary>
        /// <returns></returns>
        public long GetNextId()
        {
            return Interlocked.Increment(ref _id);
        }
    }
}
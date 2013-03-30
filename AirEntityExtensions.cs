using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// AirEntityExtensions class.
    /// </summary>
    public static class AirEntityExtensions
    {
        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="graph">The graph.</param>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(this T entity, AirGraph graph) where T : IAirEntity
        {
            return graph.TryGetAsync<T>(entity.Id);
        }
    }
}
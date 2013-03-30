using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// IAirCommand interface.
    /// </summary>
    public interface IAirCommand
    {
        /// <summary>
        /// Executes the specified graph.
        /// </summary>
        /// <param name="graph">The graph.</param>
        Task Execute(AirGraph graph);
    }
}
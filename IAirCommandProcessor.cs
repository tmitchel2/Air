using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// IAirCommandProcessor interface.
    /// </summary>
    public interface IAirCommandProcessor
    {
        /// <summary>
        /// Gets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        Task Process(IAirCommand command);
    }
}
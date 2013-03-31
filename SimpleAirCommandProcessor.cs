using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Air
{
    /// <summary>
    /// SimpleAirCommandProcessor class.
    /// </summary>
    public class SimpleAirCommandProcessor : IAirCommandProcessor
    {
        private readonly AirConfiguration _configuration;
        private readonly BufferBlock<IAirCommand> _commandQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAirCommandProcessor" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SimpleAirCommandProcessor(AirConfiguration configuration)
        {
            _configuration = configuration;
            _commandQueue = new BufferBlock<IAirCommand>();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (IsRunning)
            {
                return;
            }

            IsRunning = true;
            while (IsRunning)
            {
                throw new NotImplementedException();

                // var command = await _commandQueue.ReceiveAsync();
                // await command.Execute(_graph);
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            IsRunning = false;
        }

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public Task Process(IAirCommand command)
        {
            return _commandQueue.SendAsync(command);
        }
    }
}
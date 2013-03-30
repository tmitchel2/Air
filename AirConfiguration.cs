using System;

namespace Air
{
    /// <summary>
    /// AirConfiguration class.
    /// </summary>
    public class AirConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirConfiguration" /> class.
        /// </summary>
        public AirConfiguration()
        {
            Storage = new LocalAirStorage();
            Serialisation = new SimpleAirSerialisation();
            CommandProcessor = new SimpleAirCommandProcessor(this);
            IdFactory = new SimpleAirIdFactory(2);
        }

        /// <summary>
        /// Gets or sets the Bootstrapping.
        /// </summary>
        /// <value>
        /// The on bootstrap.
        /// </value>
        public Action<AirGraph> Bootstrapping { get; set; }

        /// <summary>
        /// Gets or sets the storage.
        /// </summary>
        /// <value>
        /// The storage.
        /// </value>
        public IAirStorage Storage { get; set; }

        /// <summary>
        /// Gets or sets the serialisation.
        /// </summary>
        /// <value>
        /// The serialisation.
        /// </value>
        public IAirSerialisation Serialisation { get; set; }

        /// <summary>
        /// Gets or sets the command processor.
        /// </summary>
        /// <value>
        /// The command processor.
        /// </value>
        public IAirCommandProcessor CommandProcessor { get; set; }

        /// <summary>
        /// Gets or sets the id factory.
        /// </summary>
        /// <value>
        /// The id factory.
        /// </value>
        public IAirIdFactory IdFactory { get; set; }
    }
}
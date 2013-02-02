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
        }

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
    }
}
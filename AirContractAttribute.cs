using System;

namespace Air
{
    /// <summary>
    /// AirContractAttribute class.
    /// </summary>
    public class AirContractAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
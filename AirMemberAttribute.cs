using System;

namespace Air
{
    /// <summary>
    /// AirMemberAttribute class.
    /// </summary>
    public class AirMemberAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Order { get; set; }
    }
}
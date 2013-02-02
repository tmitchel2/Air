using System;

namespace Air
{
    /// <summary>
    /// AirMemberAttribute class.
    /// </summary>
    public class AirMemberAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirMemberAttribute" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public AirMemberAttribute(int index)
        {
            Index = index;
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; set; }
    }
}
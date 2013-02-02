using System;

namespace Air
{
    /// <summary>
    /// AirEdgeList class.
    /// </summary>
    public class AirEdgeList : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirEdgeList" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public AirEdgeList(int index)
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
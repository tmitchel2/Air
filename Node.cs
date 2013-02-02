using System.Collections.Generic;

namespace Air
{
    /// <summary>
    /// Node struct.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the in edge ids.
        /// </summary>
        /// <value>
        /// The in edge ids.
        /// </value>
        public List<long> InEdgeIds { get; private set; }

        /// <summary>
        /// Gets the out edge ids.
        /// </summary>
        /// <value>
        /// The out edge ids.
        /// </value>
        public List<long> OutEdgeIds { get; private set; }
    }
}

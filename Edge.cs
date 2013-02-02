namespace Air
{
    /// <summary>
    /// Edge struct
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Gets the in node id.
        /// </summary>
        /// <value>
        /// The in node id.
        /// </value>
        public long InNodeId { get; private set; }

        /// <summary>
        /// Gets the out node id.
        /// </summary>
        /// <value>
        /// The out node id.
        /// </value>
        public long OutNodeId { get; private set; }
    }
}
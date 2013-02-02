using System;
using System.Collections.Generic;

namespace Air
{
    /// <summary>
    /// AirGraphNode class.
    /// </summary>
    [AirContract(Name = "AirGraph")]
    public class AirGraphNode : IAirEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets the index ids.
        /// </summary>
        /// <value>
        /// The index ids.
        /// </value>
        [AirEdgeList(0)]
        public IList<Tuple<string, long>> IdsByIndexName { get; private set; }
    }
}
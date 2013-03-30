using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Air
{
    /// <summary>
    /// AirGraphNode class.
    /// </summary>
    [DataContract]
    public class AirGraphNode : IAirEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirGraphNode" /> class.
        /// </summary>
        public AirGraphNode()
        {
            Id = 1;
            NextAvailableId = 2;
            IdsByIndexName = new List<Tuple<string, long>>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [DataMember(Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the next available id.
        /// </summary>
        /// <value>
        /// The next available id.
        /// </value>
        [DataMember(Order = 2)]
        public long NextAvailableId { get; set; }

        /// <summary>
        /// Gets the index ids.
        /// </summary>
        /// <value>
        /// The index ids.
        /// </value>
        [DataMember(Order = 3)]
        public IList<Tuple<string, long>> IdsByIndexName { get; private set; }
    }
}
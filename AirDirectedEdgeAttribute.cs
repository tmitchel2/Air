using System;

namespace Air
{
    public class AirDirectedEdgeAttribute : Attribute
    {
        public string Name { get; set; }

        public EdgeDirection Direction { get; set; }
    }
}
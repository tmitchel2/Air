using System;

namespace Air
{
    /// <summary>
    /// SimpleAirSerialisation class.
    /// </summary>
    public class SimpleAirSerialisation : IAirSerialisation
    {
        public IAirSerialiser Get(Type type)
        {
            return new SimpleAirSerialiser();
        }
    }
}
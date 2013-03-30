using System;

namespace Air
{
    /// <summary>
    /// SimpleAirSerialisation class.
    /// </summary>
    public class SimpleAirSerialisation : IAirSerialisation
    {
        private readonly IAirSerialiser _serialiser;
        
        public SimpleAirSerialisation()
        {
            _serialiser = new ProtoAirSerialiser();   
        }

        /// <summary>
        /// Gets the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IAirSerialiser Get(Type type)
        {
            //if (type.GetCustomAttributes(typeof(AirContractAttribute), true).Any())
            //{
            //    return new SimpleAirSerialiser();
            //}
            return _serialiser;
        }
    }
}
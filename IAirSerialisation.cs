using System;

namespace Air
{
    /// <summary>
    /// IAirSerialisation interface.
    /// </summary>
    public interface IAirSerialisation
    {
        /// <summary>
        /// Gets the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IAirSerialiser Get(Type type);
    }
}
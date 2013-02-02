namespace Air
{
    /// <summary>
    /// IAirSerialiser interface.
    /// </summary>
    public interface IAirSerialiser
    {
        /// <summary>
        /// Deserialises the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        T Deserialise<T>(byte[] data);

        /// <summary>
        /// Serialises the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        byte[] Serialise(IAirEntity item);
    }
}
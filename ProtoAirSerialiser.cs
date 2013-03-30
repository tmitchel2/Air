using System.IO;

namespace Air
{
    /// <summary>
    /// ProtoAirSerialiser class.
    /// </summary>
    public class ProtoAirSerialiser : IAirSerialiser
    {
        /// <summary>
        /// Deserialises the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public T Deserialise<T>(byte[] data) where T : IAirEntity
        {
            return ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(data));
        }

        /// <summary>
        /// Serialises the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public byte[] Serialise(IAirEntity item)
        {
            using (var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, item);
                return stream.ToArray();
            }
        }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using ProtoBuf;

namespace Air
{
    /// <summary>
    /// SimpleAirSerialiser class.
    /// </summary>
    public class SimpleAirSerialiser : IAirSerialiser
    {
        /// <summary>
        /// Deserialises the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public T Deserialise<T>(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serialises the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public byte[] Serialise(IAirEntity item)
        {
            var stream = new MemoryStream();
            using (var writer = new ProtoWriter(stream, null, null))
            {
                int fieldNumber = 1;
                ProtoWriter.WriteFieldHeader(fieldNumber, WireType.Fixed64, writer);
                ProtoWriter.WriteInt64(item.Id, writer);

                var props = item.GetType()
                    .GetProperties()
                    .Where(IsAirMember)
                    .OrderBy(GetAirMemberIndex);

                foreach (var prop in props)
                {
                    var value = prop.GetGetMethod().Invoke(item, new object[] { });
                    if (value is string)
                    {
                        ProtoWriter.WriteFieldHeader(++fieldNumber, WireType.String, writer);
                        ProtoWriter.WriteString(value as string, writer);    
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }

            }
            return stream.ToArray();
        }

        private int GetAirMemberIndex(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<AirMemberAttribute>().Index;
        }

        private static bool IsAirMember(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<AirMemberAttribute>() != null;
        }
    }
}
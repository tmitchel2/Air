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
        public T Deserialise<T>(byte[] data) where T : IAirEntity
        {
            return default(T);

            //var stream = new MemoryStream(data);
            //using (var reader = new ProtoReader(stream, null, null))
            //{
            //    var item = new T();

            //    var fieldNumber = reader.ReadFieldHeader();
            //    item.Id = reader.ReadInt64();

            //    var props = typeof(T)
            //        .GetProperties()
            //        .Where(IsAirMember)
            //        .OrderBy(GetAirMemberOrder);

            //    foreach (var prop in props)
            //    {

            //    }

            //    return item;
            //}
        }

        /// <summary>
        /// Serialises the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public byte[] Serialise(IAirEntity item)
        {
            var stream = new MemoryStream();
            using (var writer = new ProtoWriter(stream, null, null))
            {
                writer.SetRootObject(item);
                int fieldNumber = 1;
                ProtoWriter.WriteFieldHeader(fieldNumber, WireType.Fixed64, writer);
                ProtoWriter.WriteInt64(item.Id, writer);

                var props = item.GetType()
                    .GetProperties()
                    .Where(IsAirMember)
                    .OrderBy(GetAirMemberOrder);

                foreach (var prop in props)
                {
                    var value = prop.GetGetMethod().Invoke(item, new object[] { });
                    if (value is string)
                    {
                        ProtoWriter.WriteFieldHeader(++fieldNumber, WireType.String, writer);
                        ProtoWriter.WriteString(value as string, writer);    
                    }
                    else if (value is long)
                    {
                        ProtoWriter.WriteFieldHeader(++fieldNumber, WireType.Fixed64, writer);
                        ProtoWriter.WriteInt64((long) value, writer);    
                    }
                    else if (value is DateTime)
                    {
                        ProtoWriter.WriteFieldHeader(++fieldNumber, WireType.Fixed64, writer);
                        ProtoWriter.WriteInt64(((DateTime)value).Ticks, writer);
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }

            }
            return stream.ToArray();
        }

        private int GetAirMemberOrder(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<AirMemberAttribute>().Order;
        }

        private static bool IsAirMember(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<AirMemberAttribute>() != null;
        }
    }
}
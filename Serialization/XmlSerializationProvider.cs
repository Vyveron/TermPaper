using System.IO;
using System.Text;

namespace Lab_3_1
{
    public sealed class XmlSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T data)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using var memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, data);

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
        
        public T Deserialize<T>(string data)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using var memoryStream = new MemoryStream();
            
            memoryStream.Write(Encoding.UTF8.GetBytes(data));

            return (T)serializer.Deserialize(memoryStream);
        }
    }
}
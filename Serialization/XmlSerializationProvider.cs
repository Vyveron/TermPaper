using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;

namespace Lab_3_1
{
    public sealed class XmlSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T data)
        {
            using var input = new MemoryStream();
            var formatter = new XmlSerializer(typeof(T));
            
            formatter.Serialize(input, data);
            input.Seek(0, SeekOrigin.Begin);

            using var output = new MemoryStream();
            using var deflateStream = new DeflateStream(output, CompressionMode.Compress);
            
            input.CopyTo(deflateStream);
            deflateStream.Close();

            return Convert.ToBase64String(output.ToArray());
        }
        
        public T Deserialize<T>(string data)
        {
            using var input = new MemoryStream(Convert.FromBase64String(data));
            using var deflateStream = new DeflateStream(input, CompressionMode.Decompress);
            using var output = new MemoryStream();
            
            deflateStream.CopyTo(output);
            deflateStream.Close();
            output.Seek(0, SeekOrigin.Begin);

            var formatter = new XmlSerializer(typeof(T));
            var message = (T)formatter.Deserialize(output);
            
            return message;
        }
    }
}
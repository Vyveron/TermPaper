using System.Collections.Generic;
using System.IO;
using Lab_3_1;

namespace Database
{
    public sealed class Database<T>
    {
        private readonly string _path;
        private readonly ISerializationProvider _serializationProvider;
        
        public List<T> Entities = new();
        
        public Database(string path, ISerializationProvider serializationProvider)
        {
            _path = path;
            _serializationProvider = serializationProvider;
        }

        public void Add(T entity) => Entities.Add(entity);

        public void Remove(T entity) => Entities.Remove(entity);

        public void SerializeAndSave()
        {
            var data = _serializationProvider.Serialize(Entities);

            File.WriteAllText(_path, data);
        }

        public void Restore()
        {
            var data = File.ReadAllText(_path);

            Entities = _serializationProvider.Deserialize<List<T>>(data);
        }

        public void Wipe()
        {
            Entities.Clear();
        }
    }
}
namespace Lab_3_1
{
    public sealed class JsonSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T data)
        {
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
        
        public T Deserialize<T>(string data)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(data);
        }
    }
}
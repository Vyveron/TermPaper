namespace Lab_3_1
{
    public interface ISerializationProvider
    {
        string Serialize<T>(T data);

        T Deserialize<T>(string data);
    }
}
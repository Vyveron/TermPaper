using System.Text.Json.Serialization;
namespace Entities;

[Serializable]
public sealed class Affair
{
    [JsonInclude] public string Name;

    public Affair()
    {
        Name = "";
    }
    
    public Affair(string name)
    {
        Name = name;
    }
}
using System.Text.Json.Serialization;
namespace Entities;

[Serializable]
public sealed class Worker
{
    [JsonInclude] public string Name;
    [JsonInclude] public int Age;
    [JsonInclude] public int ExperienceYears;

    public Worker()
    {
        Name = "";
    }

    public Worker(string name, int age, int experienceYears)
    {
        Name = name;
        Age = age;
        ExperienceYears = experienceYears;
    }
}
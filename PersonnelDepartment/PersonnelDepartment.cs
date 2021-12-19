using System.Collections;
using Database;
using Entities;
using Lab_3_1;

namespace PersonnelDepartment;

public sealed class PersonnelDepartment
{
    private readonly Database<KeyValuePair<Worker, List<Affair>>> _database;

    public PersonnelDepartment()
    {
        _database = new("database.txt", new JsonSerializationProvider());
    }

    public IEnumerable<KeyValuePair<Worker, List<Affair>>> GetDatabase() => _database.Entities;

    public void AddWorker(Worker worker) => _database.Add(new(worker, new()));

    public void RemoveWorker(Worker worker)
    {
        var entity = Find(worker);

        if (entity == null)
            return;

        _database.Remove(entity.Value);
    }

    public void AddAffair(Worker worker, string affair)
    {
        var entity = Find(worker);

        if (entity == null)
            throw new ArgumentException("No such worker", nameof(worker));

        entity.Value.Value.Add(new(affair));
    }

    public void Save() => _database.SerializeAndSave();

    public void Restore() => _database.Restore();

    public void Wipe() => _database.Wipe();

    private KeyValuePair<Worker, List<Affair>>? Find(Worker worker)
    {
        if (worker == null)
            throw new NullReferenceException(nameof(worker));
        
        foreach (var entity in _database.Entities)
        {
            if (entity.Key == worker)
                return entity;
        }

        return null;
    }
}
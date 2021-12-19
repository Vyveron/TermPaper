using System;
using Database;
using Entities;
using Lab_3_1;
using NUnit.Framework;

namespace UnitTests;

public class DatabaseTest
{
    [Test]
    public void JsonTest()
    {
        var database = new Database<Worker>("tests.txt", new JsonSerializationProvider());

        database.Add(new Worker("Josh", 25, 5));
        database.SerializeAndSave();
        database.Wipe();
        database.Restore();

        Assert.AreEqual(database.Entities[0].Age, 25);
    }

    [Test]
    public void XmlTest()
    {
        var database = new Database<Worker>("tests.txt", new BinarySerializationProvider());

        database.Add(new Worker("Josh", 25, 5));
        database.SerializeAndSave();
        database.Wipe();
        database.Restore();

        Assert.AreEqual(database.Entities[0].Age, 25);
    }
    
    [Test]
    public void BinaryTest()
    {
        var database = new Database<Worker>("tests.txt", new XmlSerializationProvider());

        database.Add(new Worker("Josh", 25, 5));
        database.SerializeAndSave();
        database.Wipe();
        database.Restore();

        Assert.AreEqual(database.Entities[0].Age, 25);
    }

    [Test]
    public void WipeTest()
    {
        var database = new Database<int>("tests.txt", new JsonSerializationProvider());

        database.Add(4);
        database.SerializeAndSave();
        database.Wipe();
        
        Assert.AreEqual(database.Entities.Count, 0);
    }
}
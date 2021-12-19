
using Entities;

public static class Programm
{
    private static readonly PersonnelDepartment.PersonnelDepartment _department = new();
    private static readonly Dictionary<string, Action> _options = new()
    {
        {
            "1", FillWorkers
        },
        {
            "2", Output
        },
        {
            "3", _department.Save
        },
        {
            "4", _department.Restore
        },
        {
            "5", _department.Wipe
        },
    };
    
    public static void Main(string[] args)
    {
        string input;

        do
        {
            Console.Clear();

            foreach (var (command, action) in _options)
                Console.WriteLine($"{command} - {action.Method.Name}");
    
            Console.Write("input: ");
    
            input = Console.ReadLine() ?? string.Empty;

            if (!_options.TryGetValue(input!, out var option))
                continue;
            
            Console.Clear();
            option?.Invoke();
        }
        while(input != "exit");
    }
    

    private static void FillWorkers()
    {
        for (var i = 0; i < 10; i++)
        {
            var worker = new Worker($"Worker{i}", 20 + i, i);

            _department.AddWorker(worker);

            for (var j = 0; j < 3; j++)
                _department.AddAffair(worker, i.ToString());
        }
    }

    private static void Output()
    {
        foreach (var (worker, affairs) in _department.GetDatabase())
        {
            Console.WriteLine($"{worker.Name}: ");

            foreach (var affair in affairs)
                Console.WriteLine($"\t{affair.Name}");
        }

        Console.Read();
    }
}
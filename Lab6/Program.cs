using System.Diagnostics;
using BenchmarkDotNet.Attributes;

public class Program
{
    public static List<string> items = new List<string> { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
    
    public static void Main()
    {
        // int usersQuantity = 10;
        // CreateUsers(usersQuantity);
        // BatchProcess(2);
        BatchProcessParallel(2);
    }
    
    private static void CreateUsers(int usersQuantity)
    {
        Console.Write($"Principal Thread: {Environment.CurrentManagedThreadId}");
        
        for (int i = 0; i < usersQuantity; i++)
        {
            int taskNumber = i;
            ThreadPool.QueueUserWorkItem(ProcessUser, taskNumber);
        }
        
        Thread.Sleep(2000);
        Console.WriteLine("Users created");
    }
    
    private static void ProcessUser(object state)
    {
        int taskNumber = (int)state;
        Console.WriteLine($"Thread {taskNumber}: {Environment.CurrentManagedThreadId}");
        
        Thread.Sleep(1000);
        
        Console.WriteLine($"User processed. Thread {taskNumber}");
    }

    private static void BatchProcess(int batchSize)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        int batchNumber = 1;
        
        var batch = items.Take(batchSize).ToList();
        
        while (items.Count > 0)
        {
            Console.WriteLine($"Processing Batch {batchNumber}");
            
            foreach (var item in batch)
            {
                Console.WriteLine(item);
                Thread.Sleep(500);
            }
            
            Console.WriteLine($"Batch {batchNumber} processed");
            
            items = items.Skip(batchSize).ToList();
            batch = items.Take(batchSize).ToList();
            batchNumber++;
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Total time (BatchProcess): {stopwatch.ElapsedMilliseconds} ms");
    }
    
    private static void BatchProcessParallel(int batchSize)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        Console.WriteLine("Initializing processing in parallel");
        
        int batch = 0;
        var batches = items.Chunk(batchSize);

        foreach (var batchItems in batches)
        {
            Console.WriteLine($"Processing Batch {batch}");
            
            Parallel.ForEach(batchItems, item =>
            {
                Console.WriteLine(item);
                Thread.Sleep(100);
            });   
            
            Console.WriteLine($"Batch {batch} processed"); 
            batch++;
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Total time (BatchProcessParallel): {stopwatch.ElapsedMilliseconds} ms");
    }
}
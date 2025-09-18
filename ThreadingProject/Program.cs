using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void PrintingNumbers(string name, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"{name}: {i}");
            //Creates a pause that helps display threading better
            Thread.Sleep(50);
        }
    }

    static void ThreadingWithoutSyncNumbers()
    {
        //Running without syncronization (All threads run together) 
        Thread t1 = new Thread(() => PrintingNumbers("Thread #1", 1, 10));
        Thread t2 = new Thread(() => PrintingNumbers("Thread #2", 11, 20));
        Thread t3 = new Thread(() => PrintingNumbers("Thread #3", 21, 30));
        Thread t4 = new Thread(() => PrintingNumbers("Thread #4", 31, 40));

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("Done!");
    }

    static void ThreadingWithSyncNumbers(){
        //Running with syncronization/in order (one thread at a time)
        Thread t5 = new Thread(() => PrintingNumbers("Thread #1", 1, 10));
        Thread t6 = new Thread(() => PrintingNumbers("Thread #2", 11, 20));
        Thread t7 = new Thread(() => PrintingNumbers("Thread #3", 21, 30));
        Thread t8 = new Thread(() => PrintingNumbers("Thread #4", 31, 40));

        t5.Start();
        t5.Join(); 

        t6.Start();
        t6.Join();

        t7.Start();
        t7.Join();

        t8.Start();
        t8.Join();

        Console.WriteLine("Done!");
    }

    static void ThreadingWithPriorities()
    {
        
    }

    static void Main()
    {
        // Measure ThreadingWithoutSyncNumbers (milliseconds)
        var sw1 = Stopwatch.StartNew();
        ThreadingWithoutSyncNumbers();
        sw1.Stop();
        double ms = sw1.Elapsed.TotalMilliseconds;
        Console.WriteLine($"ThreadingWithoutSyncNumbers elapsed: {ms:F3} ms");
        Console.WriteLine("--------------------------------------------------");

        // Measure ThreadingWithSyncNumbers (milliseconds)
        var sw2 = Stopwatch.StartNew();
        ThreadingWithSyncNumbers();
        sw2.Stop();
        ms = sw2.Elapsed.TotalMilliseconds;
        Console.WriteLine($"ThreadingWithSyncNumbers elapsed: {ms:F3} ms");
        Console.WriteLine("--------------------------------------------------");
    }
}
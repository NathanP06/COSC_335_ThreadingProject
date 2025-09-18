using System;
using System.Threading;

class Program
{
    static void PrintingNumbers(string name, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"{name}: {i}");
            Thread.Sleep(500);
        }
    }

    static void Main()
    {
        //Running without syncronization
        Thread t1 = new Thread(() => PrintingNumbers("Thread #1", 1, 10));
        Thread t2 = new Thread(() => PrintingNumbers("Thread #2", 11, 20));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Done!");

        //Running with syncronization/in order
        Thread t3 = new Thread(() => PrintingNumbers("Thread #3", 21, 30));
        Thread t4 = new Thread(() => PrintingNumbers("Thread #4", 31, 40));

        t3.Start();
        t3.Join();

        t4.Start();
        t4.Join();

        Console.WriteLine("Done!");

    }
}
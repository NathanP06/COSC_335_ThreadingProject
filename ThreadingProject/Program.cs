using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    //Method to print numbers
    static void PrintingNumbers(string name, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"{name}: {i}");
            //Creates a pause that helps display threading better
            Thread.Sleep(50);
        }
    }

    //Running without syncronization (All threads run together)
    static void ThreadingWithoutSyncNumbers()
    {
        //Creates 5 threads
        Thread t1 = new Thread(() => PrintingNumbers("Thread #1", 1, 10));
        Thread t2 = new Thread(() => PrintingNumbers("Thread #2", 11, 20));
        Thread t3 = new Thread(() => PrintingNumbers("Thread #3", 21, 30));
        Thread t4 = new Thread(() => PrintingNumbers("Thread #4", 31, 40));
        Thread t5 = new Thread(() => PrintingNumbers("Thread #5", 41, 50));

        //Starts all five threads
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();

        //Waits for threads to complete before continuing
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();
        t5.Join();

        //Prints "done" to inform user that tasks have been completed
        Console.WriteLine("Done!");
    }
    
    //Running with syncronization/in order (one thread at a time)
    static void ThreadingWithSyncNumbers()
    {
        //Creates 5 threads
        Thread t6 = new Thread(() => PrintingNumbers("Thread #1", 1, 10));
        Thread t7 = new Thread(() => PrintingNumbers("Thread #2", 11, 20));
        Thread t8 = new Thread(() => PrintingNumbers("Thread #3", 21, 30));
        Thread t9 = new Thread(() => PrintingNumbers("Thread #4", 31, 40));
        Thread t10 = new Thread(() => PrintingNumbers("Thread #5", 41, 50));

        //Starts thread, waits for it to finish, then starts next thread
        t6.Start();
        t6.Join();

        t7.Start();
        t7.Join();

        t8.Start();
        t8.Join();

        t9.Start();
        t9.Join();

        t10.Start();
        t10.Join();

        //Prints "done" to inform user that tasks have been completed
        Console.WriteLine("Done!");
    }


    //Method to print threads based off priority
    static void PrintPriority(string name, int seconds)
    {
        long counter = 0;

        //Creates a variable that stores a DateTime value of the current time plus the number of seconds passed in
        DateTime end = DateTime.Now.AddSeconds(seconds);

        // Busy loop until the time expires
        while (DateTime.Now < end)
        {
            counter++;
        }

        //Prints the name, priority, and number of iterations completed by the thread
        Console.WriteLine($"{name} with priority {Thread.CurrentThread.Priority} finished with {counter:N0} iterations.");
    }
        static void ThreadingWithoutPriorities()
    {
        // Creating 3 new threads with different values
        Thread t11 = new Thread(() => PrintPriority("Thread #11", 5));
        Thread t12 = new Thread(() => PrintPriority("Thread #12", 5));
        Thread t13 = new Thread(() => PrintPriority("Thread #13", 5));

        // Start threads
        t11.Start();
        t12.Start();
        t13.Start();

        // Wait for all threads to complete
        t11.Join();
        t12.Join();
        t13.Join();

        Console.WriteLine("All values printed with the same priorities!");
    }

    static void ThreadingWithPriorities()
    {
        // Creating 3 new threads with different values
        Thread t14 = new Thread(() => PrintPriority("Thread #11", 5));
        Thread t15 = new Thread(() => PrintPriority("Thread #12", 5));
        Thread t16 = new Thread(() => PrintPriority("Thread #13", 5));

        // Set different priorities for each thread
        t14.Priority = ThreadPriority.Highest;
        t15.Priority = ThreadPriority.Normal;
        t16.Priority = ThreadPriority.Lowest;

        // Start threads
        t14.Start();
        t15.Start();
        t16.Start();

        // Wait for all threads to complete
        t14.Join();
        t15.Join();
        t16.Join();

        Console.WriteLine("All values printed with different thread priorities!");
    }

    static void Main()
    {
        // Measure ThreadingWithoutSyncNumbers (milliseconds)
        //Creates stopwatch object, runs method, then stops the stop watch)
        var sw1 = Stopwatch.StartNew();
        ThreadingWithoutSyncNumbers();
        sw1.Stop();

        //Stores value in variable ms
        double ms = sw1.Elapsed.TotalMilliseconds;

        //prints elapsed time to console
        Console.WriteLine($"ThreadingWithoutSyncNumbers elapsed: {ms:F3} ms");
        Console.WriteLine("--------------------------------------------------");

        // Measure ThreadingWithSyncNumbers (milliseconds)
        //Does the same as above but for the other method
        var sw2 = Stopwatch.StartNew();
        ThreadingWithSyncNumbers();
        sw2.Stop();
        ms = sw2.Elapsed.TotalMilliseconds;
        Console.WriteLine($"ThreadingWithSyncNumbers elapsed: {ms:F3} ms");
        Console.WriteLine("--------------------------------------------------");

        //Runs the priorities method
        ThreadingWithoutPriorities();
        ThreadingWithPriorities();
    }
}
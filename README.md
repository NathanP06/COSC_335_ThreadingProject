# COSC_335_ThreadingProject
A project for COSC 335 (Operating Systems) in C# focusing on the use Threading.

This project is aimed at demonstrating an understanding of developing using Threading techniques.

It contains three primary methods: ThreadingWithoutSyncNumbers, ThreadingWithSyncNumbers, and ThreadingWithPriorities.

ThreadingWithoutSyncNumbers is a program that shows the efficency of splitting up numerous actions into different threads, allowing for the CPU to more effectively run multiple processes/threads simoultaniously. This method starts all 5 threads at relatively the same time, to demonstrate the threads running whenever the processor will allow them to, without worry for the other threads.

ThreadingWithSyncNumbers is a program that demonstrates the opposite. It runs the threads in sync, showing that running one thread at a time creates a process that runs slower, in this instance, the ".Start()" method call, starts the read and ".Join()" waits for the individual thread to finish completely running before it rejoins the main method call.

ThreadingWithPriorities is a completely different set of instructions, that has no relation to the above two. This method has three threads in it, with each thread being labeled a priority: high, normal, or low. It uses a While loop and the date & time of the computer to run the thread counter for 5 seconds, incrementing the counter as many times as it can which essentially demonstrates how long each of these processes spent within the processor. This allows for the user to effectively see how priorities are working within the Threading example.

In the main method, there are two stopwatch objects that time how long each method (ThreadingWithSyncNumbers and ThreadingWithoutSyncNumbers) take, which is what demonstrates the different in speed the two programs run.
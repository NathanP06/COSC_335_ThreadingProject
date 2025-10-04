# COSC_335_ThreadingProject

A C# project for COSC 335 (Operating Systems) demonstrating basic threading techniques.

Overview
- The project contains four primary demonstrations:
  - `WithoutSync` — creates five threads that run concurrently; each thread prints a sequence of numbers and uses `Thread.Sleep(50)` to make output readable.
  - `WithSync` — runs the same five tasks but starts each thread and immediately `Join()`s it, so the tasks execute one at a time (synchronous behavior).
  - `WithoutPriorities` — creates three threats and does not assign them priorities (lets the system apply priorities) and busy-loops for 5 seconds, incrementing a counter; the final counts indicate how much work each thread completed.
  - `WithPriorities` — runs the same three tasks but assigns different priorities (`Highest`, `Normal`, `Lowest`). Shows a comparison between prioritized threading vs unprioritized threading

Notes on timing and priorities
- `Main` measures and prints the elapsed time for `WithoutSync` and `WithSync` using `Stopwatch` to illustrate the performance difference.
- Thread priorities are scheduler hints and platform-dependent. To observe priority effects, the priority threads should be started concurrently (call `Start()` on all threads first, then `Join()` them) so the OS scheduler can interleave them. If you start a thread and immediately `Join()` it (run sequentially), you won't see scheduling arbitration between threads.

Implementation details
- `PrintingNumbers(string name, int start, int end)` prints the named sequence for each thread.
- `PrintPriority(string name, int seconds)` busy-loops for `seconds` and prints the thread's priority and its counter when finished.
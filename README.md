# C# Async/Await Pitfalls & Best Practices

A dual-project showcase (Console + WinForms) demonstrating common async/await traps, their causes, and best practices to avoid them.

## Context Capture & ConfigureAwait

### Key Concepts
- **SynchronizationContext** – Present in UI apps (WinForms/WPF), absent in Console apps.
- **Context Capture** – Default behavior (`ConfigureAwait(true)`) returns to original context after await.
- **ConfigureAwait(false)** – Prevents context capture, continues on ThreadPool.

### Demonstrations
- Console App: Thread ID changes or stays the same – no real difference (no context).
- WinForms UI App: 
  - Without ConfigureAwait(false): returns to UI thread after await.
  - With ConfigureAwait(false): stays on ThreadPool.
- Best practice: Use `ConfigureAwait(false)` in library code to avoid performance issues and deadlocks.

## Deadlock in UI (Sync over Async)

- 3 common deadlock scenarios in WinForms:
  1. .Result on async method
  2. .Wait() on async method
  3. Library code without ConfigureAwait(false)
- Fixes:
  - ConfigureAwait(false) in library code
  - Task.Run for sync over async
  - Full async chain (preferred)

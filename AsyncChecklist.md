# Personal Async/Await Checklist (C# Best Practices)

Before committing any async code, check these 10 items:

1. **Use ConfigureAwait(false) in library code**  
   All `await` calls in non-UI code (services, helpers, libraries) must have `.ConfigureAwait(false)` to prevent context capture and deadlocks.

2. **Never use .Result or .Wait() in UI or sync code**  
   Avoid sync over async. Use full async chain (`await`) or `Task.Run` if necessary.

3. **Always pass CancellationToken**  
   Long-running or I/O operations must accept `CancellationToken` and pass it to async calls (e.g., HttpClient, Task.Delay).

4. **Handle OperationCanceledException**  
   Catch and handle cancellation gracefully (don't swallow it).

5. **Implement timeout for external calls**  
   Use `CancellationTokenSource(timeout)` for HttpClient, database, or external API calls.

6. **Avoid fire-and-forget without safety**  
   If using fire-and-forget, wrap in try-catch + logging or use `ContinueWith` to observe exceptions.

7. **Use async all the way**  
   If a method is async, all callers should be async (no mixing sync/async).

8. **Prefer ValueTask for hot paths**  
   Use `ValueTask<T>` instead of `Task<T>` in frequently called methods to reduce allocations.

9. **Use IAsyncEnumerable for large/streaming data**  
   For large collections or streaming, return `IAsyncEnumerable<T>` and use `await foreach`.

10. **Test with real delays and cancellation**  
   Always test async code with delays, cancellation, and timeouts to catch deadlocks and issues early.

Follow this checklist to write safe, performant, and maintainable async code.
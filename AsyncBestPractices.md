| Pitfall                | Short Explanation                                               | Best Practice                                                      |
| ---------------------- | --------------------------------------------------------------- | ------------------------------------------------------------------ |
| Context Capture        | `await` returns to the previous context (such as the UI thread) | In libraries, always use `ConfigureAwait(false)`                   |
| Deadlock               | Sync-over-async (`.Result` or `.Wait()` on the UI thread)       | Be fully async (`await`) or use `Task.Run`                         |
| Fire-and-Forget        | Exceptions are lost; lifetime issues                            | Use try-catch inside the method + logging, or `ContinueWith`       |
| Forgotten Cancellation | The operation cannot be cancelled                               | Always pass and check `CancellationToken`                          |
| Forgotten Timeout      | Long-running operations block the application                   | Use `CancellationTokenSource(timeout)`                             |
| Misuse of Task.Run     | Used for I/O-bound work                                         | Use `Task.Run` only for CPU-bound work; for I/O use direct `await` |

using System.Threading.Tasks;

public static class SafeFireAndForget
{
    // Method 1: try-catch inside the method + simple logging
    public static async Task SafeWithTryCatchAsync()
    {
        try
        {
            await Task.Delay(1000);
            throw new System.Exception("Exception was caught!");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"[LOG] Exception in SafeWithTryCatch: {ex.Message}");
        }
    }

    // Method 2: Task.Run for CPU-bound or long-running operations
    public static void SafeWithTaskRun()
    {
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(2000);
                Console.WriteLine("Long-running operation with Task.Run finished");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"[LOG] Exception in Task.Run: {ex.Message}");
            }
        });
    }

    // Method 3: ContinueWith to capture exceptions (without blocking)
    public static void SafeWithContinueWith()
    {
        Task.Delay(1000)
            .ContinueWith(t =>
            {
                if (t.IsFaulted)
                    Console.WriteLine($"[LOG] Exception in ContinueWith: {t.Exception?.GetBaseException().Message}");
                else
                    Console.WriteLine("Operation finished with ContinueWith");
            }, TaskScheduler.Default);
    }

    // Method 4: Safe Fire-and-Forget with logging (best for libraries)
    public static void FireAndForgetSafe(this Task task)
    {
        task.ContinueWith(t =>
        {
            if (t.IsFaulted)
                Console.WriteLine($"[LOG] Unobserved exception: {t.Exception?.GetBaseException().Message}");
        }, TaskScheduler.Default);
    }
}

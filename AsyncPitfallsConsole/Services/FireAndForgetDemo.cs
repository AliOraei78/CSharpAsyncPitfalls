using System.Threading.Tasks;

public static class FireAndForgetDemo
{
    // Async method that throws an exception
    public static async Task ThrowExceptionAsync()
    {
        await Task.Delay(1000);
        throw new System.Exception("This exception gets lost in Fire-and-Forget!");
    }

    // Bad Fire-and-Forget (exception is lost)
    public static void BadFireAndForget()
    {
        // Without await — the exception is lost and the program may crash
        ThrowExceptionAsync();
        Console.WriteLine("Bad Fire-and-Forget executed (but the exception was lost)");
    }

    // Fire-and-Forget with try-catch (exception is caught)
    public static void SafeFireAndForgetWithCatch()
    {
        Task.Run(async () =>
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        });
        Console.WriteLine("Safe Fire-and-Forget executed");
    }

    // Fire-and-Forget with logging (best practice)
    public static void SafeFireAndForgetWithLogging()
    {
        _ = ThrowExceptionAsync().ContinueWith(t =>
        {
            if (t.IsFaulted)
                Console.WriteLine($"Exception in Fire-and-Forget: {t.Exception?.GetBaseException().Message}");
        }, TaskScheduler.Default);

        Console.WriteLine("Fire-and-Forget with logging executed");
    }

    // Long-running operation (10 seconds)
    public static async Task LongRunningFireAndForgetAsync()
    {
        Console.WriteLine("Long-running Fire-and-Forget operation started (10 seconds)...");

        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Second {i} has passed...");
        }

        Console.WriteLine("Long-running operation finished!");
    }

    // Bad Fire-and-Forget (lifetime issue)
    public static void BadLifetimeFireAndForget()
    {
        // Without await — if the application closes quickly, the operation remains incomplete
        LongRunningFireAndForgetAsync();
        Console.WriteLine("Bad Fire-and-Forget executed (if the application closes, the operation will be interrupted)");
    }

    // Safer Fire-and-Forget with Task.Run (better, but still stops if the application closes)
    public static void SafeLifetimeFireAndForget()
    {
        Task.Run(async () =>
        {
            await LongRunningFireAndForgetAsync();
        });
        Console.WriteLine("Fire-and-Forget executed with Task.Run");
    }
}

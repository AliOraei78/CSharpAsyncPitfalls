public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Context Capture in Console App ===\n");

        await ConfigureAwaitDemo.RunWithDefaultContextAsync();

        await ConfigureAwaitDemo.RunWithoutContextAsync();

        await ConfigureAwaitDemo.RunWithTaskRunAsync();

        Console.WriteLine("=== Scenario 1: Lost Exceptions in Fire-and-Forget ===");

        FireAndForgetDemo.BadFireAndForget();
        // the exception is lost (the application may crash)

        FireAndForgetDemo.SafeFireAndForgetWithCatch();
        // the exception is caught and printed

        FireAndForgetDemo.SafeFireAndForgetWithLogging();
        // the exception is captured using ContinueWith

        Console.WriteLine("\nThe application continued running (if it didn’t crash!)");

        Console.WriteLine("=== Scenario 2: Lifetime issue in Fire-and-Forget ===");

        FireAndForgetDemo.BadLifetimeFireAndForget();

        // Close the application quickly (Ctrl+C or close the window)
        // Observe that the operation is interrupted and
        // "Long-running operation finished!" is not printed

        Console.WriteLine("\nClose the application quickly to see the operation being interrupted!");

        Console.ReadKey();
    }
}
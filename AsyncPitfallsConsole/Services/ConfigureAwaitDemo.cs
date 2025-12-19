using System.Threading;
using System.Threading.Tasks;

public static class ConfigureAwaitDemo
{
    // Test with ConfigureAwait(true) - default
    public static async Task RunWithDefaultContextAsync()
    {
        Console.WriteLine($"Thread before await (default): {Thread.CurrentThread.ManagedThreadId}");

        await Task.Delay(100);

        Console.WriteLine($"Thread after await (default): {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Usually returns to the same thread or ThreadPool (in Console it doesn’t matter)\n");
    }

    // Test with ConfigureAwait(false)
    public static async Task RunWithoutContextAsync()
    {
        Console.WriteLine($"Thread before await (false): {Thread.CurrentThread.ManagedThreadId}");

        await Task.Delay(100).ConfigureAwait(false);

        Console.WriteLine($"Thread after await (false): {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Stays on ThreadPool, does not return to original context\n");
    }

    // Test combined with Task.Run
    public static async Task RunWithTaskRunAsync()
    {
        Console.WriteLine($"Thread before Task.Run: {Thread.CurrentThread.ManagedThreadId}");

        await Task.Run(async () =>
        {
            Console.WriteLine($"Inside Task.Run: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"After await inside Task.Run: {Thread.CurrentThread.ManagedThreadId}");
        });

        Console.WriteLine($"Thread after Task.Run: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Task.Run itself does not capture the context\n");
    }
}

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Context Capture in Console App ===\n");

        await ConfigureAwaitDemo.RunWithDefaultContextAsync();

        await ConfigureAwaitDemo.RunWithoutContextAsync();

        await ConfigureAwaitDemo.RunWithTaskRunAsync();

        Console.ReadKey();
    }
}
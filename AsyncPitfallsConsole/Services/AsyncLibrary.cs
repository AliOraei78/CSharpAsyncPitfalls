using System.Threading.Tasks;

public static class AsyncLibrary
{
    // Bad version (without ConfigureAwait(false))
    public static async Task<string> GetDataBadAsync()
    {
        await Task.Delay(3000); // Context is captured (if running in UI)
        return "Data from Library (Bad)";
    }

    // Correct version (with ConfigureAwait(false))
    public static async Task<string> GetDataGoodAsync()
    {
        await Task.Delay(3000).ConfigureAwait(false); // Context is not captured
        return "Data from Library (Good)";
    }
}

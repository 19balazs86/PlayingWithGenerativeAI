using ConsoleAppSK.Examples;

namespace ConsoleAppSK;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await KernelInvokePrompt.Run("Who are you?", enableLogging: false);
    }
}
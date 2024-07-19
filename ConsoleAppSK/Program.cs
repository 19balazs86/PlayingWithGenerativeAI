using ConsoleAppSK.Examples;

namespace ConsoleAppSK;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await E01_KernelInvokePrompt.Run("Who are you?");

        await E02_ChatWithHistory.Run();

        //await E03_DescribeImage.Run();

        //await E04_TextToImage.Run();

        //await E05_EmbeddingSimilarity.Run();
    }
}
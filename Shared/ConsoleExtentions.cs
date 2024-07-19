namespace Shared;

public static class ConsoleExtentions
{
    private const ConsoleColor _aiColor = ConsoleColor.Green;

    public static void WriteAI(this TextWriter writer, string? message)
    {
        Console.ForegroundColor = _aiColor;

        writer.Write(message);

        Console.ResetColor();
    }

    public static void WriteLineAI(this TextWriter writer, string? message)
    {
        Console.ForegroundColor = _aiColor;

        writer.WriteLine(message);

        Console.ResetColor();
    }
}

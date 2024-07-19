namespace Shared;

public static class ConsoleExtentions
{
    public static TextWriter AI(this TextWriter writer)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        return writer;
    }

    public static TextWriter User(this TextWriter writer)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        return writer;
    }

    public static TextWriter ResetColor(this TextWriter writer)
    {
        Console.ResetColor();

        return writer;
    }
}

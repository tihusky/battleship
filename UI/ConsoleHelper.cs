namespace Battleship.UI;

internal static class ConsoleHelper
{
    /// <summary>
    /// Writes the given text to the console without inserting a line break at the end.
    /// Can optionally change the color of the output.
    /// </summary>
    /// <param name="message">The text to be displayed in the console.</param>
    /// <param name="color">The color of the output.</param>
    public static void Write(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes the given text to the console, followed by a line break. Can optionally
    /// change the color of the output.
    /// </summary>
    /// <param name="message">The text to be displayed in the console.</param>
    /// <param name="color">The color of the output.</param>
    public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
    {
        Write(message + '\n', color);
    }

    /// <summary>
    /// Reads user input from the console and returns it with all characters being uppercased 
    /// and leading and trailing whitespace removed.
    /// </summary>
    public static string? GetUppercasedString()
    {
        return Console.ReadLine()?.Trim().ToUpper();
    }
}
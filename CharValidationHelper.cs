using System.Text;

namespace ValidationUtility
{
    internal class CharValidationHelper
    {
        public static string CharPasswordCreator(string prompt, bool showHiddenOutput)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string userInput = "";
            Console.Write(prompt);

            while (true)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    userInput += key.KeyChar;
                    if (showHiddenOutput)
                    {
                        Console.Write((char)2534);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && userInput.Length > 0)
                    {
                        userInput = userInput.Substring(0, (userInput.Length - 1));
                        if (showHiddenOutput)
                        {
                            Console.Write("\b \b");
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (string.IsNullOrEmpty(userInput))
                        {
                            Console.WriteLine("\nEmpty value not allowed.");
                            userInput = "";
                        }
                        else
                        {
                            return userInput;
                        }

                    }
                }
            }
        }
    }
}
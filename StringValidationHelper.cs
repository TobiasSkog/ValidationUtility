using System.Text.RegularExpressions;

namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Strings.
    /// </summary>
    public class StringValidationHelper
    {
        public static string GetString(string prompt)
        {
            while (true)
            {
                KeyboardValidationHelper.IsToggleKeysEnabled(true, false);

                Console.Write(prompt);

                string? userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }

                Console.WriteLine("Invalid input. You cannot use an empty text or only white spaces.");
            }
        }

        public static string GetStringWhiteSpaceAllowed(string prompt)
        {
            while (true)
            {
                KeyboardValidationHelper.IsToggleKeysEnabled(true, false);

                Console.Write(prompt);

                string? userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }

                Console.WriteLine("Invalid input. You cannot use an empty text.");
            }
        }

        public static string GetCleanSpectreConsoleString(string input, string pattern = @"\[(.*?)\](.*?)\[/\]")
        {
            Match match = Regex.Match(input, pattern);

            string labelText = match.Groups[2].Value;
            string cleanedLabel = string.Join("", labelText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            return cleanedLabel;
        }
    }
}

namespace ValidationHelper
{
    internal class StringValidationHelper
    {
        public static string GetString(string prompt)
        {
            while (true)
            {
                KeyboardValidationHelper.IsToggleKeysEnabled(true, true);

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
                KeyboardValidationHelper.IsToggleKeysEnabled(true, true);

                Console.Write(prompt);

                string? userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }

                Console.WriteLine("Invalid input. You cannot use an empty text or only white spaces.");
            }
        }
    }
}

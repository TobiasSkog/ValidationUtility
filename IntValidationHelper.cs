namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Integers.
    /// </summary>
    public class IntValidationHelper
    {

        public static int GetIntegerNoMinOrMaxRange(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int validInt))
                {
                    return validInt;
                }
            }
        }
        public static int GetInteger(string prompt, int minRange)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int validInt))
                {
                    if (validInt >= minRange)
                    {
                        return validInt;
                    }
                }

                Console.WriteLine($"Invalid input. Number must be an integer greater or equal to {minRange}.");
            }
        }

        public static int GetIntegerRange(string prompt, int minRange, int maxRange, string errorMessage = $"Invalid input. Number must be an integer within the range ")
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int validInt))
                {
                    if (validInt >= minRange && validInt <= maxRange)
                    {
                        return validInt;
                    }
                }

                Console.WriteLine($"{errorMessage} ({minRange} - {maxRange}).");
            }
        }

        public static int CountWords(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return words.Length;
        }
    }
}

namespace ValidationUtility
{
    public class IntValidationHelper
    {
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

        public static int GetIntegerRange(string prompt, int minRange, int maxRange)
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

                Console.WriteLine($"Invalid input. Number must be an integer within the range ({minRange} - {maxRange}).");
            }
        }
    }
}

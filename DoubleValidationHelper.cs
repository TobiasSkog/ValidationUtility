namespace ValidationHelper
{
    internal class DoubleValidationHelper
    {
        public static double GetDouble(string prompt, double minRange)
        {
            while (true)
            {
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out double validDouble))
                {
                    if (validDouble >= minRange)
                    {
                        return validDouble;
                    }
                }

                Console.WriteLine($"Invalid input. Number must be a double greater or equal to {minRange}.");
            }
        }

        public static double GetDoubleRange(string prompt, double minRange, double maxRange)
        {
            while (true)
            {
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out double validDouble))
                {
                    if (validDouble >= minRange && validDouble <= maxRange)
                    {
                        return validDouble;
                    }
                }

                Console.WriteLine($"Invalid input. Number must be a double within the range ({minRange} - {maxRange}).");
            }
        }
    }
}

using System.Globalization;

namespace ValidationUtility
{
    internal class DateTimeValidationHelper
    {
        public static DateTime GetDateTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (DateTime.TryParse(Console.ReadLine(), out DateTime validDateTime))
                {
                    return validDateTime;
                }

                Console.WriteLine("Invalid date format. Enter a valid date and time.");
            }
        }

        public static DateTime GetExactDateTime(string prompt, string format)
        {
            while (true)
            {
                Console.Write(prompt);

                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDateTime))
                {
                    return validDateTime;
                }

                Console.WriteLine($"Invalid date format. Enter a valid date and time in the format {format}.");
            }
        }

        public static DateTime GetPresentDateTime(string prompt)
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                DateTime userInput = GetDateTime(prompt);

                if (userInput <= now)
                {
                    return userInput;
                }

                Console.WriteLine("Invalid date. The date and time must be in the past.");
            }
        }

        public static DateTime GetFutureDateTime(string prompt)
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                DateTime userInput = GetDateTime(prompt);

                if (userInput > now)
                {
                    return userInput;
                }

                Console.WriteLine("Invalid date. The date and time must be in the future.");
            }
        }

        public static DateTime GetDateTimeRange(string prompt, DateTime minDateTime, DateTime maxDateTime)
        {
            while (true)
            {
                DateTime userInput = GetDateTime(prompt);

                if (userInput >= minDateTime && userInput <= maxDateTime)
                {
                    return userInput;
                }

                Console.WriteLine($"Invalid input. The date and time must be between ({minDateTime} and {maxDateTime}).");
            }
        }
    }
}

using System.Globalization;

namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for DateTimes.
    /// </summary>
    public class DateTimeValidationHelper
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
                Console.Write($"{prompt} in this format ({format.ToUpper()}): ");

                if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime validDateTime))
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

        public static DateTime GetExactPresentDateTime(string prompt, string format)
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                DateTime userInput = GetExactDateTime(prompt, format);

                if (userInput <= now)
                {
                    return userInput;
                }

                Console.WriteLine($"Invalid date. The date and time must be in the past, with the format {format}.");
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

        public static DateTime GetExactFutureDateTime(string prompt, string format)
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                DateTime userInput = GetExactDateTime(prompt, format);

                if (userInput > now)
                {
                    return userInput;
                }

                Console.WriteLine($"Invalid date. The date and time must be in the future, with the format {format}.");
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
        public static DateTime GetExactDateTimeRange(string prompt, string format, DateTime minDateTime, DateTime maxDateTime)
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
        public static DateTime GetDateTimeAgeRestriction(string prompt, int ageRestriction)
        {
            DateTime dateToday = DateTime.Now;
            while (true)
            {
                DateTime userDateOfBirth = GetDateTime(prompt);
                int userAge = dateToday.Year - userDateOfBirth.Year;

                if (userAge >= ageRestriction)
                {
                    return userDateOfBirth;
                }
                Console.WriteLine($"Invalid input. The age restriction is {ageRestriction}!\n" +
                $"You are {ageRestriction - userAge} years too young.");
            }
        }
        public static DateTime GetExactDateTimeAgeRestriction(string prompt, string format, int ageRestriction)
        {
            DateTime dateToday = DateTime.Now;
            while (true)
            {
                DateTime userDateOfBirth = GetExactDateTime(prompt, format);
                int userAge = dateToday.Year - userDateOfBirth.Year;

                if (userAge >= ageRestriction)
                {
                    return userDateOfBirth;
                }

                Console.WriteLine($"Invalid input. The age restriction is {ageRestriction}!\n" +
                $"You are {ageRestriction - userAge} years too young.");
            }
        }


    }
}

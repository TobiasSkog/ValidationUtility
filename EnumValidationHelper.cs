namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Enums.
    /// </summary>
    public class EnumValidationHelper
    {
        public static T GetEnumValue<T>(string prompt) where T : struct
        {
            try
            {
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type.");
                }

                while (true)
                {
                    Console.WriteLine(prompt);

                    if (Enum.TryParse(Console.ReadLine(), true, out T ValidEnumValue))
                    {
                        return ValidEnumValue;
                    }

                    Console.WriteLine("Invalid input. Enter a valid option.");
                }
            }
            catch (ArgumentException ex)
            {
                ExceptionHelper.ExceptionDetails(ex);
                return default;
            }
        }
    }
}

namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Enums.
    /// </summary>
    public class EnumValidationHelper
    {
        public static T GetEnumValueFromRange<T>() where T : struct
        {
            try
            {
                Type enumType = typeof(T);

                if (!enumType.IsEnum)
                {
                    throw new ArgumentException("T must be an Enum type.");
                }

                string[] enumNames = Enum.GetNames(enumType);


                Console.WriteLine("These are the available types:");
                for (int i = 0; i < enumNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {enumNames[i]}");
                }
                int userChoice = IntValidationHelper.GetIntegerRange("Choose a type: ", 1, enumNames.Length);

                string selectedEnumName = enumNames[userChoice - 1];

                if (!Enum.TryParse(selectedEnumName, out T validEnumValue))
                {
                    throw new ArgumentException("Invalid Enum value.");
                }
                return validEnumValue;
            }
            catch (ArgumentException ex)
            {
                ExceptionHelper.ExceptionDetails(ex);
                return default;
            }
        }

        public static T GetSpecificEnumValue<T>(string enumName) where T : struct
        {
            try
            {
                Type enumType = typeof(T);

                if (!enumType.IsEnum)
                {
                    throw new ArgumentException("T must be an Enum type.");
                }

                string[] enumNames = Enum.GetNames(enumType);

                if (!Enum.TryParse(enumName, out T validEnumValue))
                {
                    throw new ArgumentException($"Invalid Enum value \"{enumName}\".");
                }
                return validEnumValue;
            }
            catch (ArgumentException ex)
            {
                ExceptionHelper.ExceptionDetails(ex);
                return default;
            }
        }

    }
}


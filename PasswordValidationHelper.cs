namespace ValidationUtility
{
    public class PasswordValidationHelper
    {
        public static string PasswordValidation(
            string prompt,
            byte minLength = 8,
            byte maxLength = 113,
            bool mustHaveSpecialCharacters = true,
            bool mustHaveNumbers = true,
            bool mustHaveLowerAndUpperCaseLetters = true,
            bool avoidIllegalChars = false,
            char[]? specialChars = null,
            char[]? illegalChars = null)
        {
            specialChars ??= new char[] {
            '@', '#', '$', '%', '^', '&','*', '-',
            '_', '!', '+', '=','[', ']', '{', '}',
            '|', '\\',':', '\'', ',', '.', '?', '/',
            '`', '~', '"', '(', ')', ';','<', '>' };

            while (true)
            {
                bool hasDigit = false, hasLower = false, hasUpper = false, hasSpecial = false, hasIllegal = false;

                List<string> errorMessages = new List<string>();

                string userInput = StringValidationHelper.GetString(prompt).Trim();

                foreach (char c in userInput)
                {
                    if (mustHaveNumbers && char.IsDigit(c))
                    {
                        hasDigit = true;
                    }

                    if (mustHaveLowerAndUpperCaseLetters)
                    {
                        if (char.IsLower(c))
                        {
                            hasLower = true;
                        }
                        if (char.IsUpper(c))
                        {
                            hasUpper = true;
                        }
                    }

                    if (mustHaveSpecialCharacters && specialChars.Contains(c))
                    {
                        hasSpecial = true;
                    }

                    if (avoidIllegalChars && illegalChars != null && illegalChars.Contains(c))
                    {
                        hasIllegal = true;
                    }
                }

                if (userInput.Length < minLength || userInput.Length > maxLength)
                {
                    errorMessages.Add($"Password must be between {minLength} and {maxLength} characters.");
                }

                if (mustHaveNumbers && !hasDigit)
                {
                    errorMessages.Add("Password must contain at least one digit.");
                }

                if (mustHaveLowerAndUpperCaseLetters && (!hasLower || !hasUpper))
                {
                    errorMessages.Add("Password must contain both lower and upper case letters.");
                }

                if (mustHaveSpecialCharacters && !hasSpecial)
                {
                    errorMessages.Add("Password must contain at least one special character.");
                }

                if (avoidIllegalChars && hasIllegal)
                {
                    errorMessages.Add("Password contains illegal characters.");
                }

                // If there are error messages, display them and ask the user to recreate the password
                if (errorMessages.Count > 0)
                {
                    ExceptionHelper.ExceptionDetails("Password validation failed. Please fix the following issues:", errorMessages);
                }
                else
                {
                    return userInput;
                }
            }
        }
    }
}

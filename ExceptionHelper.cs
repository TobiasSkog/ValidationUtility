namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Exceptions.
    /// </summary>

    // TODO: Handle specific Exceptions based on the Exception thrown.
    public class ExceptionHelper
    {
        public static void ExceptionDetails(Exception ex)
        {
            // Checking if the user wants a detailed error message or not
            if (BoolValidationHelper.PromptForYesOrNo("See detailed error message? (Y)es or (N)o: "))
            {
                Console.WriteLine($"Error Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Help Link: {ex.HelpLink}");
            }
            else
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ExceptionDetails(string prompt, List<string> errorMessages)
        {
            Console.WriteLine(prompt);

            foreach (string errorMessage in errorMessages)
            {
                Console.WriteLine($"- {errorMessage}");
            }
        }
    }
}

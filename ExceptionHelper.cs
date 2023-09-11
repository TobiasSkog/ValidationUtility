﻿namespace ValidationHelper
{
    internal class ExceptionHelper
    {
        public static void ExceptionDetails(Exception ex)
        {
            // Checking if the user wants a detailed error message or not
            if (BoolValidationHelper.PromptForYesOrNo())
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
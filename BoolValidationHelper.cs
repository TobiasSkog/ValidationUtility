﻿namespace ValidationUtility
{
    internal class BoolValidationHelper
    {
        public static bool PromptForYesOrNo(string prompt = "Answer (Y)es or (N)o: ")
        {
            while (true)
            {
                string userInput = StringValidationHelper.GetString(prompt).Trim().ToUpper();
                if (userInput == "YES" || userInput == "Y")
                {
                    return true;
                }
                if (userInput == "NO" || userInput == "N")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Answer must be (Y)es or (N)o.");
            }
        }
    }
}
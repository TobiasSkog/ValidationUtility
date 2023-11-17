using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationUtility
{
  /// <summary>
  /// Validation Helper Class for Strings.
  /// </summary>
  public class StringValidationHelper
  {
    public static string GetString(string prompt)
    {
      while (true)
      {
        KeyboardValidationHelper.IsToggleKeysEnabled(true, false);

        Console.Write(prompt);

        string? userInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(userInput))
        {
          return userInput;
        }

        Console.WriteLine("Invalid input. You cannot use an empty text or only white spaces.");
      }
    }

    public static string GetStringWhiteSpaceAllowed(string prompt)
    {
      while (true)
      {
        KeyboardValidationHelper.IsToggleKeysEnabled(true, false);

        Console.Write(prompt);

        string? userInput = Console.ReadLine();

        if (!string.IsNullOrEmpty(userInput))
        {
          return userInput;
        }

        Console.WriteLine("Invalid input. You cannot use an empty text.");
      }
    }

    public static string GetCleanSpectreConsoleString(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true, string pattern = @"\[(.*?)\](.*?)\[/\]")
    {
      Regex regex = new Regex(pattern);

      string result = regex.Replace(input, match =>
      {

        string content = match.Groups[2].Value;

        return content;
      });

      return result;
    }
    public static string GetCleanSpectreConsoleStringCapitalized(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true, string pattern = @"\[(.*?)\](.*?)\[/\]")
    {
      Regex regex = new Regex(pattern);

      string result = regex.Replace(input, match =>
      {

        string content = match.Groups[2].Value;

        return content;
      });

      return CapitalizeWords(result, avoidAllWhiteSpaces, avoidStartEndWhiteSpaces);
    }
    public static string GetCleanSpectreConsoleStringForEnums(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true, string pattern = @"\[(.*?)\](.*?)\[/\]")
    {
      Regex regex = new Regex(pattern);

      string result = regex.Replace(input, match =>
      {

        string content = match.Groups[2].Value;

        return content;
      });

      return CapitalizeAndJoinWords(result, avoidAllWhiteSpaces, avoidStartEndWhiteSpaces);
    }
    public static string GetCleanSpectreConsoleStringForEnumsOnly(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true, string pattern = @"\[(.*?)\](.*?)\[/\]")
    {
      Regex regex = new Regex(pattern);

      string result = regex.Replace(input, match =>
      {

        string content = match.Groups[2].Value;

        return content;
      });

      return result;
    }

    public static string CapitalizeFirstCharacter(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true)
    {
      string formattedInput = "";

      if (string.IsNullOrEmpty(input))
      {
        return formattedInput;
      }
      if (avoidAllWhiteSpaces)
      {
        formattedInput = input.Replace(" ", "");
      }
      if (!avoidAllWhiteSpaces && avoidStartEndWhiteSpaces)
      {
        formattedInput = input.Trim();
      }

      formattedInput = formattedInput.First().ToString().ToUpper() + formattedInput.Substring(1).ToLower();

      return formattedInput;
    }
    public static string CapitalizeAndJoinWords(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true)
    {
      string formattedInput = "";
      List<string> inputWordList = new();
      List<string> formattedWordsList = new();

      if (string.IsNullOrEmpty(input))
      {
        return formattedInput;
      }

      inputWordList.AddRange(input.Split(' '));

      foreach (string word in inputWordList)
      {
        formattedWordsList.Add(CapitalizeFirstCharacter(word, avoidAllWhiteSpaces, avoidStartEndWhiteSpaces));
      }

      formattedInput = string.Join("", formattedWordsList);

      return formattedInput;
    }

    public static string CapitalizeWords(string input, bool avoidAllWhiteSpaces = true, bool avoidStartEndWhiteSpaces = true)
    {
      string formattedInput = "";
      List<string> inputWordList = new();
      List<string> formattedWordsList = new();

      if (string.IsNullOrEmpty(input))
      {
        return formattedInput;
      }

      inputWordList.AddRange(input.Split(' '));

      foreach (string word in inputWordList)
      {
        formattedWordsList.Add(CapitalizeFirstCharacter(word, avoidAllWhiteSpaces, avoidStartEndWhiteSpaces));
      }

      formattedInput = string.Join(" ", formattedWordsList);

      return formattedInput;
    }
    public static string CreateRandomString(int length = 60, string AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
    {
      Random Random = new Random();

      char[] randomUserId = new char[length];
      for (int i = 0; i < length; i++)
      {
        randomUserId[i] = AllowedChars[Random.Next(0, AllowedChars.Length)];
      }
      return new string(randomUserId);
    }

    public static (List<string> ErrorMessages, string UserInput) GetCleanSpectreConsoleUserInformation(
          string userInput,
          bool onlyOneWord = true,
          byte minLength = 5,
          byte maxLength = 113,
          bool avoidWhiteSpaces = true,
          bool avoidIllegalChars = true,
          char[]? illegalChars = null)
    {
      illegalChars ??= new char[] {
            '@', '#', '$', '%', '^', '&','*', '-',
            '_', '!', '+', '=','[', ']', '{', '}',
            '|', '\\',':', '\'', ',', '.', '?', '/',
            '`', '~', '"', '(', ')', ';','<', '>' };

      bool hasIllegal, hasWhiteSpace, hasManyWords;
      List<string> errorMessages;
      while (true)
      {
        hasIllegal = false; hasWhiteSpace = false; hasManyWords = false;
        errorMessages = new List<string>();
        foreach (char c in userInput)
        {
          if (avoidIllegalChars && illegalChars != null && illegalChars.Contains(c))
          {
            hasIllegal = true;
          }

          if (avoidWhiteSpaces)
          {
            if (c == ' ')
            {
              hasWhiteSpace = true;
            }
          }
          if (onlyOneWord)
          {
            if (IntValidationHelper.CountWords(userInput) != 1)
            {
              hasManyWords = true;
            }
          }
        }

        if (avoidWhiteSpaces && hasWhiteSpace)
        {
          errorMessages.Add($"Text contains white spaces.");
        }
        if (userInput.Length < minLength || userInput.Length > maxLength)
        {
          errorMessages.Add($"Text must be between {minLength} and {maxLength} characters.");
        }

        if (avoidIllegalChars && hasIllegal)
        {
          errorMessages.Add("Text contains illegal characters.");
        }

        if (onlyOneWord && hasManyWords)
        {
          errorMessages.Add("Text can only contain one word.");
        }

        userInput = StringValidationHelper.GetCleanSpectreConsoleString(userInput);

        return (ErrorMessages: errorMessages, UserInput: userInput.Trim());
      }
    }
  }
}
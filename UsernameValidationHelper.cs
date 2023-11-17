using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationUtility
{
  public class UsernameValidationHelper
  {
    public static (List<string> ErrorMessages, string Username) SpectreConsoleUsernameValidation(
            string username,
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

      bool hasIllegal, hasWhiteSpace;
      List<string> errorMessages;
      while (true)
      {
        hasIllegal = false; hasWhiteSpace = false;
        errorMessages = new List<string>();
        foreach (char c in username)
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
        }

        if (avoidWhiteSpaces && hasWhiteSpace)
        {
          errorMessages.Add($"Username contains white spaces.");
        }
        if (username.Length < minLength || username.Length > maxLength)
        {
          errorMessages.Add($"Username must be between {minLength} and {maxLength} characters.");
        }

        if (avoidIllegalChars && hasIllegal)
        {
          errorMessages.Add("Username contains illegal characters.");
        }

        username = StringValidationHelper.GetCleanSpectreConsoleString(username);

        return (ErrorMessages: errorMessages, Username: username.Trim());
      }
    }
  }
}

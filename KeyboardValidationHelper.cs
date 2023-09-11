using System.Runtime.InteropServices;

namespace ValidationUtility
{
    /// <summary>
    /// Validation Helper Class for Keyboard Specific Validation.<br></br>
    /// Control if Capslock and / or Numbers Lock is on / off.<br></br>
    /// Writes to the console if the Trigger(s) key is activated.
    /// </summary>

    public class KeyboardValidationHelper
    {
        private static readonly bool _windowsOS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        //private static readonly bool _linuxOS = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// Prints out to the console if user OS is Windows and Capslock is enabled.
        /// </summary>
        public static void IsCapsLockEnabled()
        {
            if (_windowsOS && Console.CapsLock)
            {
                Console.WriteLine("Caps Lock is activated!");
            }
        }

        /// <summary>
        /// Prints out to the console if user OS is Windows and Numlock is enabled.
        /// </summary>
        public static void IsNumLockEnabled()
        {
            if (_windowsOS && Console.NumberLock)
            {
                Console.WriteLine("Numbers Lock is activated!");
            }
        }

        /// <summary>
        /// Require the user to be on Windows.<br></br>
        /// Checks if Capslock and / or Numlock is enabled and writes to console.<br></br> 
        /// </summary>
        /// <param name="checkCapsLock">Make a "Caps Lock Control" and Write out a warning to the console?</param>
        /// <param name="checkNumlock">Make a "Numbers Lock Control" and Write out a warning to the console?</param>
        public static void IsToggleKeysEnabled(bool checkCapsLock, bool checkNumlock)
        {
            if (checkCapsLock)
            {
                IsCapsLockEnabled();
            }
            if (checkNumlock)
            {
                IsNumLockEnabled();
            }
        }
    }
}

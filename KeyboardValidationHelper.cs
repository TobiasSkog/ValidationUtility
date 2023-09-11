using System.Runtime.InteropServices;

namespace ValidationHelper
{
    internal class KeyboardValidationHelper
    {
        private static readonly bool _windowsOS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        //private static readonly bool _linuxOS = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static void IsCapsLockEnabled()
        {
            if (_windowsOS && Console.CapsLock)
            {
                Console.WriteLine("Caps Lock is activated!");
            }
        }

        public static void IsNumLockEnabled()
        {
            if (_windowsOS && Console.NumberLock)
            {
                Console.WriteLine("Numbers Lock is activated!");
            }
        }

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

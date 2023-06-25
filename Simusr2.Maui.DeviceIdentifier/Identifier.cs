#if ANDROID
using Android.Provider;
#elif IOS || MACCATALYST
using UIKit;
#endif

namespace Simusr2.Maui.DeviceIdentifier
{
    // All the code in this file is included in all platforms.
    public static class Identifier
    {
        /// <summary>
        /// Return device identifier based on current platform
        /// </summary>
        /// <returns>Device identifier</returns>
        public static string Get() {
#if WINDOWS
return WindowsIdentifier.GetProcessorId();
#elif ANDROID
        return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Settings.Secure.AndroidId);
#elif IOS || MACCATALYST
        return UIDevice.CurrentDevice.IdentifierForVendor?.ToString();
#else
            return null;
#endif
        }
    }
}
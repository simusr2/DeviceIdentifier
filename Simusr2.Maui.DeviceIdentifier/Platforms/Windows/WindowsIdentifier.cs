using System.Management;

namespace Simusr2.Maui.DeviceIdentifier;

// All the code in this file is only included on Windows.
internal static class WindowsIdentifier
{
    internal static string GetProcessorId()
    {
        string query = "Select ProcessorID From Win32_processor";
        string key = "ProcessorID";
        return SearchManagementObject(query, key);
    }

    private static string SearchManagementObject(string query, string key)
    {
        string value = null;
        foreach (ManagementBaseObject mo in new ManagementObjectSearcher(query).Get())
        {
            value = mo[key] as string;
        }

        return value;
    }
}
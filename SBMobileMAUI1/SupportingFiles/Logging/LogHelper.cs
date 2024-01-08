namespace SBMobileMAUI1;

public class LogHelper
{
    public LogHelper()
    {
    }
    public static string GetLogFileFolder()
    {

        string baseflder = string.Empty;

        if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
            baseflder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            baseflder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        else
            throw new Exception("Could not initialize Logger: Unknown Platform");

        return System.IO.Path.Combine(baseflder, "logs");
    }

    /// <summary>
    /// full name path to log file (template)
    /// </summary>
    public static string GetLogFilename()
    {
        return System.IO.Path.Combine(GetLogFileFolder(), "log.json");
    }

    /// <summary>
    /// return arrary of log files
    /// </summary>
    /// <returns></returns>
    public static string[] GetFiles()
    {
        var logfilefolder = GetLogFileFolder();

        return System.IO.Directory.GetFiles(logfilefolder, "log*.json");
    }
}

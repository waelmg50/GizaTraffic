using System.Configuration;

namespace GizaTraffic.Settings
{
    internal sealed class AppSettings : ApplicationSettingsBase
    {
        private static readonly AppSettings _default =
            (AppSettings)Synchronized(new AppSettings());

        public static AppSettings Default => _default;

        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string PrinterName
        {
            get => (string)this[nameof(PrinterName)];
            set => this[nameof(PrinterName)] = value;
        }

        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string PrintingPath
        {
            get => (string)this[nameof(PrintingPath)];
            set => this[nameof(PrintingPath)] = value;
        }
    }
}

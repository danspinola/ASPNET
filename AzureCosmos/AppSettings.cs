using Microsoft.Extensions.Configuration;

namespace AzureCosmos
{
    public class AppSettings
    {
        public string StorageConnectionString { get; set; }

        public static AppSettings LoadAppSettings()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .AddJsonFile("Settings.json")
                .Build();

            AppSettings appSettings = configRoot.Get<AppSettings>();
            return appSettings;
        }
    }
}


using Microsoft.Extensions.Configuration;

namespace NorthWind.Helpers;

public static class HelperConfiguration
{
    public static AppConfiguration GetAppConfiguration(
        string configurationFile = "AppJson")
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile(configurationFile, optional: false)
            .Build();

        var Result = configuration.Get<AppConfiguration>();
        return Result;
    }
}

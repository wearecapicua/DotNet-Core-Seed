using Microsoft.Extensions.Configuration;
using System.IO;

namespace Providers
{
    public static class Configuration
    {
        public static string GetSection(string value)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            return builder.Build()[value];
        }
    }
}

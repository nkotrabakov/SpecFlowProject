using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using static SpecFlowProject.Common.Configurations.ConfigurationLabels;

namespace SpecFlowProject.Common.Configurations
{
    public static class ConfigurationProvider
    {
        public static IConfiguration GetValue { get; }

        static ConfigurationProvider()
        {
            GetValue = GetConfiguration(CurrentEnvironment);

            var environment = GetValue[EnvironmentProperty];

            GetValue = environment switch
            {
                Dev => GetConfiguration(DevSettings),
                Local => GetConfiguration(LocalSettings),
                Test => GetConfiguration(TestSettings),

                _ => throw new ApplicationException("Wrong environment value!")
            };
        }

        private static IConfiguration GetConfiguration(string fileName)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName)
                .Build();
        }
    }
}

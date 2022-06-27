namespace SpecFlowProject.Common.Configurations
{
    public class ConfigurationLabels
    {
        //Common
        public const string CurrentEnvironment = "CurrentEnvironment.json";
        public const string EnvironmentProperty = "Environment";
        public const string Dev = "Dev";
        public const string Local = "Local";
        public const string Test = "Test";
        public const string DevSettings = "appsettingsDev.json";
        public const string TestSettings = "appsettingsDev.json";
        public const string LocalSettings = "appsettingsDev.json";
        public const string Chromium = "Chromium";
        public const string Firefox = "Firefox";
        public const string Webkit = "Webkit";

        //WEB
        public const string DefaultImplicitTimeout = "WEB:DefaultImplicitTimeout";
        public const string BaseWebUrl = "WEB:BaseWebUrl";
        public const string RegisterWebUrl = "WEB:RegisterWebUrl";
        
        //REST
        public const string BaseApiUrl = "REST:BaseApiUrl";
        public const string UsersEndPoint = "REST:UsersEndPoint";

        //DB
        public const string DBConnectionString = "DB:DBConnectionString";
    }
}

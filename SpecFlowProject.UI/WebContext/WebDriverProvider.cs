using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.IO;
using Allure.Commons;
using System.Reflection;

namespace SpecFlowProject.UI.WebContext
{
    internal class WebDriverProvider
    {
        private static IWebDriver _driver;
        private static ScenarioContext _scenarioContext;

        internal static void InitChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        internal static IWebDriver GetChromeDriver()
        {
            return _driver;
        }

        public static string AssemblyDirectory
        {
            get
            {            
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        internal static void GetScreenshot(string Directory)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var filename = "screenshot_" + DateTime.Now.Ticks + ".png";
            var path = $"{Directory}/{filename}";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
        }
    }
}
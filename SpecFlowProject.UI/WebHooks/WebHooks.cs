using OpenQA.Selenium;
using SpecFlowProject.UI.WebContext;
using TechTalk.SpecFlow;

namespace SpecFlowProject.UI.WebHooks
{
    [Binding]
    internal sealed class WebHooks
    {
        private ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        private WebHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        [Scope(Tag = "web")]
        private void Setup()
        {
            WebDriverProvider.InitChromeDriver();
            _driver = WebDriverProvider.GetChromeDriver();
            _scenarioContext.Add("WebDriver", _driver);
        }

        [AfterScenario]
        [Scope(Tag = "web")]
        private void AfterScenario(ScenarioContext _scenarioContext)
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                WebDriverProvider.GetScreenshot(WebDriverProvider.AssemblyDirectory);
            }
            _driver.Dispose();
        }
    }
}

using SpecFlowProject.UI.WebContext;
using SpecFlowProject.Common.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.UI.Actions
{
    internal class BaseUserActions
    {
        private IWebDriver _driver;
        ScenarioContext _scenarioContext;
        private WebDriverWait _wait;

        public BaseUserActions(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationProvider.GetValue[ConfigurationLabels.DefaultImplicitTimeout])));
        }

        internal void OpenPage(string pageName)
        {
            _driver.Navigate().GoToUrl(pageName);
        }

        internal void TypesInto(By elementLocator, string text)
        {
            WaitsUntilClicable(elementLocator).Clear();
            Find(elementLocator).SendKeys(text);
        }

        internal void ClicksOn(By elementLocator)
        {
            WaitsUntilClicable(elementLocator).Click(); 
        }

        internal string ReadsTextFrom(By elementLocator)
        {
            return WaitsUntilVisible(elementLocator).Text.Trim();
        }
        internal IWebElement Find(By elementLocator)
        {
            return _driver.FindElement(elementLocator);
        }
        internal IWebElement WaitsUntilClicable(By elementLocator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        internal IWebElement WaitsUntilVisible(By elementLocator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }

        internal bool IsElementDisplayed(By elementLocator)
        {
            return _driver.FindElement(elementLocator).Displayed;
        }
    }
}

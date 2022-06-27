using NUnit.Framework;
using SpecFlowProject.Common.Configurations;
using SpecFlowProject.UI.Actions;
using SpecFlowProject.UI.WebContext;
using SpecFlowProject.UI.WebPages;
using TechTalk.SpecFlow;

namespace SpecFlowProject.UI.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private BaseUserActions _webUser;
        ScenarioContext _scenarioContext;

        internal LoginStepDefinitions(BaseUserActions webUser, ScenarioContext scenarioContext)
        {
            _webUser = webUser;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            _webUser.OpenPage(ConfigurationProvider.GetValue[ConfigurationLabels.BaseWebUrl]);
        }

        [When(@"I enter username '(.*)' and password '(.*)'")]
        public void WhenIEnterUsernameAndPassword(string email, string password)
        {
            _webUser.TypesInto(LoginPage.EMAIL, email);
            _webUser.TypesInto(LoginPage.PASSWORD, password);
        }

        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            _webUser.ClicksOn(LoginPage.LOGIN_BUTTON);
        }

        [Then(@"I should see error message")]
        public void ThenIShouldSeeErrorMessage()
        {
            var errorMessage = _webUser.Find(LoginPage.INVALID_USER_MESSAGE);

            Assert.AreEqual(WebLabels.InvalidUserExpectedMessage, errorMessage.Text);
        }

        [Then(@"I should see Welcome user message")]
        public void ThenIShouldSeeWelcomeUserMessage()
        {
            var welcomeMessage = _webUser.Find(HomePage.WELCOME_MESSAGE);
            var navBar = _webUser.Find(HomePage.NAVBAR_HEADER);
            var navBarButtons = _webUser.Find(HomePage.WELCOME_MESSAGE);

            Assert.Multiple(() =>
            {
                Assert.That(welcomeMessage.Displayed);
                Assert.AreEqual(WebLabels.NavBarHeader, navBar.Text);
                Assert.That(navBarButtons.Displayed);
            });
        }

        [Then(@"I should see Welcome page displayed")]
        public void ThenIShouldSeeWelcomePageDisplayed()
        {
            var welcomeHeader = _webUser.IsElementDisplayed(HomePage.NAVBAR_HEADER);

            Assert.That(welcomeHeader, Is.False, "Welcome page is not displayed.");
        }

    }
}

using BCQAExam.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace BCQAExam.Steps
{
    [Binding]
    public class RegisterNewUserSteps : BaseStepDefinition
    {
        private NavigationPage NavigationPage = new NavigationPage();
        private LoginPage LoginPage = new LoginPage();
        private MyAccountPage MyAccountPage = new MyAccountPage();
        private AuthenticationPage AuthenticationPage = new AuthenticationPage();
        private dynamic _ScenarioData;

        [Given(@"I am in the page allowing Registration")]
        public void GivenIAmInTheHomePageOfTheSystem()
        {
            NavigationPage.NavigateToHomePage();
        }

        [When(@"I enter random username only")]
        public void WhenIEnterRandomUsernameOnly()
        {
            NavigationPage.NavigateToLoginPage();
            LoginPage.Register();
        }

        [Then(@"I should be redirected to Registration Page")]
        public void ThenIShouldBeRedirectedToRegistrationPage()
        {
            AuthenticationPage.AssertAuthenticationPage();
        }

        [When(@"I fill registration form and press Register")]
        public void WhenIEnterRandomUsernameOnly(Table table)
        {
            //NavigationPage.NavigateToLoginPage();
            _ScenarioData = table.CreateDynamicInstance();

            int sc_data_zip = _ScenarioData.ZIP;
            string sc_data_zip_as_string = sc_data_zip.ToString();
            int sc_data_mobile = _ScenarioData.Mobile;
            string sc_data_mobile_as_string = sc_data_mobile.ToString();

            AuthenticationPage.Register((string)_ScenarioData.Name, (string)_ScenarioData.Lastname,
                (string)_ScenarioData.Password, (string)_ScenarioData.Address,
                (string)_ScenarioData.City, (string)_ScenarioData.State,
                sc_data_zip_as_string, sc_data_mobile_as_string);
        }

        [Then(@"I should be redirected to my account page")]
        public void ShouldBeRedirectedToMyAccountPage()
        {
            MyAccountPage.AssertAccountName();
        }

        [When(@"I press Sign out link")]
        public void IPressSignOutLink()
        {
            MyAccountPage.SignOut();
        }

        [Then(@"I should be redirected back to login page")]
        public void IShouldBeRedirectedBackToToLoginPage()
        {
            LoginPage.AssertLoginPage();
        }

        [When(@"I login with random username generated earlier")]
        public void WhenILogiWithRandomUsernameGeneratedEarlier(Table table)
        {
            //NavigationPage.NavigateToLoginPage();
            _ScenarioData = table.CreateDynamicInstance();
            LoginPage.LoginWithGeneratedUsername((string)_ScenarioData.Password);
        }

        [Then(@"I again should be redirected to my account page")]
        public void AgainShouldBeRedirectedToMyAccountPage()
        {
            MyAccountPage.AssertAccountName();
        }



    }
}

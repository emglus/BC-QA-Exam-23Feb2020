using BCQAExam.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BCQAExam.Pages
{
    public class LoginPage : BasePage
    {
        //Login
        private IWebElement Email => Driver.FindControl(By.Id("email"), true);

        private IWebElement Password => Driver.FindControl(By.Id("passwd"), true);

        private IWebElement LoginButton => Driver.FindControl(By.Id("SubmitLogin"), true);

        public void Login(string email = null, string password = null)
        {
            Email.Clear();
            Email.SendKeys(email);
            Password.Clear();
            Password.SendKeys(password);
            LoginButton.Click();
        }

        public void LoginWithGeneratedUsername(string password = null)
        {
            Email.Clear();
            Email.SendKeys(RandomNameGenerator.Email);
            Password.Clear();
            Password.SendKeys(password);
            LoginButton.Click();
        }


        //Registration
        private IWebElement EmailCreate => Driver.FindControl(By.Id("email_create"), true);

        private IWebElement RegisterButton => Driver.FindControl(By.Id("SubmitCreate"), true);

        public void Register()
        {
            // this is the only time per test when we call Generate();
            RandomNameGenerator.Generate();

            // Only the randomly generated email is used, while name and last name come from the feature. 
            TestContext.Progress.WriteLine("==> Note randomly generated email for future reference: {0}", RandomNameGenerator.Email);

            EmailCreate.Clear();
            EmailCreate.SendKeys(RandomNameGenerator.Email);
            RegisterButton.Click();
        }

        private IWebElement LoginLink => Driver.FindControl(By.ClassName("login"), true);

        public void AssertLoginPage()
        {
            Assert.AreEqual("Sign in", LoginLink.Text);
        }
    }
}

using BCQAExam.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BCQAExam.Pages
{
    public class MyAccountPage:BasePage
    {
        private IWebElement AccountName => Driver.FindControl(By.XPath("//a[@title='View my customer account']"), true);
        private IWebElement MyAccountTab => Driver.FindControl(By.XPath("//span[@class='navigation_page']"), true);

        public void AssertAccountName()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Lorena De Canas", AccountName.Text);
                Assert.AreEqual("My account", MyAccountTab.Text);
            });
        }

        private IWebElement SignOutButton => Driver.FindControl(By.XPath("//a[@title='Log me out']"), true);
        //private IWebElement SignOutButton2 => Driver.FindControl(By.ClassName("Logout"));

        public void SignOut()
        {
            SignOutButton.Click();
            //SignOutButton2.Click();
        }
    }
}

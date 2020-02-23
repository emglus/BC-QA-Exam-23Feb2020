using BCQAExam.Core;
using NUnit.Framework;
using OpenQA.Selenium;


namespace BCQAExam.Pages
{
    public class AuthenticationPage : BasePage
    {

        private IWebElement AuthenticationTab => Driver.FindControl(By.XPath("//span[@class='navigation_page']"), true);

        public void AssertAuthenticationPage()
        {
           Assert.Multiple(() =>
           {
               Assert.AreEqual("Authentication", AuthenticationTab.Text);
           });
        }

        //private IWebElement Name => Driver.FindControl(By.Id("customer_firstname"), true);
        // Some flakiness is observed if the Name element is located by the Id
        private IWebElement Name => Driver.FindControl(By.XPath("//*[@id='customer_firstname']"), true);

        private IWebElement Lastname => Driver.FindControl(By.Id("customer_lastname"), true);

        private IWebElement Password => Driver.FindControl(By.Id("passwd"), true);

        private IWebElement Address => Driver.FindControl(By.Id("address1"), true);

        private IWebElement City => Driver.FindControl(By.Id("city"), true);
        private IWebElement State => Driver.FindControl(By.Id("state"), true);
        private IWebElement ZIP => Driver.FindControl(By.Id("postcode"), true);
        private IWebElement Mobile => Driver.FindControl(By.Id("phone_mobile"), true);

        private IWebElement RegisterButton => Driver.FindControl(By.Id("submitAccount"), true);

        public void Register(string name = null, string lastname = null, string password = null, string address = null,
            string city = null, string state = null, string zip = null, string mobile = null)
        {
 
            Name.Clear();
            Name.SendKeys(name);
            Lastname.Clear();
            Lastname.SendKeys(lastname);

            Password.Clear();
            Password.SendKeys(password);
            Address.Clear();
            Address.SendKeys(address);

            City.Clear();
            City.SendKeys(city);

            Driver.FindControl(By.Id("id_state")).Click();
            {
                string xpath_str = @"//option[. = 'XYZ']";
                xpath_str = xpath_str.Replace("XYZ", state);
                var dropdown = Driver.FindControl(By.Id("id_state"));
                dropdown.FindElement(By.XPath(xpath_str)).Click();
            }
            Driver.FindControl(By.Id("id_state")).Click();

            ZIP.Clear();
            ZIP.SendKeys(zip);
            Mobile.Clear();
            Mobile.SendKeys(mobile);

            RegisterButton.Click();
        }

        
    }
}

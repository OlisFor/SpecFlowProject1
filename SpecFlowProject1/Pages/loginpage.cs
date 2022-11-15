using OpenQA.Selenium;
using SpecFlowProject1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class loginpage
    {
        IWebDriver driver;
        waits waits;
        IWebElement EnterUsername => driver.FindElement(By.Id("email_create"));
        IWebElement EnterPassword => driver.FindElement(By.Id("passwd"));
        IWebElement LoginButton => driver.FindElement(By.Id("other"));

        public loginpage()
        {
            driver = Hooks.driver;
            
        }
        public void Launchurl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void EnterUsernameEnterpassword(string username, string password)
        {
            EnterUsername.SendKeys(username);
            EnterPassword.SendKeys(password);
       }

        public void signinButton()
        {
            LoginButton.Click();
        }

    }
}

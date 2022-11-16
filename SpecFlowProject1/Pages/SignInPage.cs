using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class SignInPage
    {
        IWebDriver driver;
        waits waits;

        IWebElement SigninButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a"));
        IWebElement EnterSignInEmail => driver.FindElement(By.Id("email_create"));
        IWebElement ClickCreateAccountButton => driver.FindElement(By.XPath("//*[@id=\"SubmitCreate\"]/span"));
        IWebElement ClickTitleButton => driver.FindElement(By.Id("id_gender1"));
        IWebElement EnterFirstName => driver.FindElement(By.Id("customer_firstname"));
        IWebElement EnterLastName => driver.FindElement(By.Id("customer_lastname"));
        IWebElement EnterPassword => driver.FindElement(By.Id("passwd"));
        IWebElement SelectDay => driver.FindElement(By.Id("days"));
        IWebElement SelectMonth => driver.FindElement(By.Id("months"));
        IWebElement SelectYear => driver.FindElement(By.Id("years"));       
        IWebElement AddressFirstName => driver.FindElement(By.Id("firstname"));
        IWebElement AddressLastName => driver.FindElement(By.Id("lastname"));
        IWebElement Address => driver.FindElement(By.Id("addrress1"));
        IWebElement City => driver.FindElement(By.Id("city"));
        IWebElement State => driver.FindElement(By.Id("id_state"));
        IWebElement ZipCode => driver.FindElement(By.Id("postcode"));
        IWebElement AdditionalInfo => driver.FindElement(By.Id("other"));
        IWebElement HomePhoneNo => driver.FindElement(By.Id("phone"));
        IWebElement MobileNo => driver.FindElement(By.Id("phone_mobile"));
        IWebElement AssignAllias => driver.FindElement(By.Id("alias"));
        IWebElement RegisterButton => driver.FindElement(By.Id("other"));
        IWebElement SignOutButton => driver.FindElement(By.Id("other"));







        public SignInPage()
        {
            driver = Hooks.driver;
            waits = new waits();
        }

        public void LaunchURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickSignInButton()
        {
            //waits.WaitForElement(driver, SigninButton).Click();
            SigninButton.Click();
        }
        public void EnterEmailForSignIN(string email)
        {
            EnterSignInEmail.SendKeys(email);
        }

        public void ClickCreateAccount()
        { 
        ClickCreateAccountButton.Click();
        }
        public void ValidateInformationPage()
        {
            string actualTitle = "Login - My Store ";
            string expectedTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("The page Title is: " + driver.Title);

            Thread.Sleep(5000);

            //string actualtext = driver.FindElement(By.XPath(" ")).Text;
            //string expectedtext = dresses
            // Assert.AreEqual(expectedTitle, actualTitle);
        }
        public void TitleButton()
        {
            //waits.WaitForElement(driver, ClickTitleButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => ClickTitleButton).Click();
            //ClickTitleButton.Click();
        }
        public void FNameAndLName()
        {

            EnterFirstName.SendKeys("Everybody");
            EnterLastName.SendKeys("Goodday");
        }
       
        public void Password()
        {
            EnterPassword.SendKeys("NovemberBatch1");

        }
        public void Day()
        {
            SelectElement select = new SelectElement(SelectDay);
            select.SelectByIndex(6);
        }
        public void Month()
        {
            SelectElement select = new SelectElement(SelectMonth);
            select.SelectByIndex(4);

        }
        public void Year()
        {
            SelectElement select = new SelectElement(SelectYear);
            select.SelectByValue("2000");

        }

        public void EnterAddressDetails(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var test = dictionary["AddressFirstName"];

            waits.WaitForElement(driver, AddressFirstName);
            AddressFirstName.Clear();
            AddressLastName.SendKeys(dictionary["AddressFirstName"]);

            AddressLastName.Clear();
            AddressLastName.SendKeys(dictionary["AddressLastName"]);

            Address.SendKeys(dictionary["Address"]);

            City.SendKeys(dictionary["City"]);

            SelectElement select = new SelectElement(State);
            select.SelectByValue(dictionary["State"]);

            ZipCode.SendKeys(dictionary["Zip/PostalCode"]);

            AdditionalInfo.SendKeys(dictionary["AdditionalInformation"]);

            HomePhoneNo.SendKeys(dictionary["HomePhoneNumber"]);

            MobileNo.SendKeys(dictionary["MobilePhoneNumber"]);

            AssignAllias.SendKeys(dictionary["AddressAllias"]);

        }
        //create click registratio
        public void regButton ()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => RegisterButton);

            RegisterButton.Click();
        }

        public void ValidateSuccessfullRegistration()
        {
            bool status = SignOutButton.Displayed;
            if (status)
                Console.WriteLine(SignOutButton.Text,  "+ is displayed");
            else
                Console.WriteLine("Login Failed");

            Thread.Sleep(3000);
        }

    }
   
}

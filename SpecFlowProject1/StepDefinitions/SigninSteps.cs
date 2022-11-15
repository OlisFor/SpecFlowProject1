using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class SigninSteps
    {
        SignInPage signInPage;

        public SigninSteps()
        {
            signInPage = new SignInPage();
        }
        [Given(@"I navigate to the website ""([^""]*)""")]
        public void GivenINavigateToTheWebsite(string url)
        {
            signInPage.LaunchURL(url);
        }

        [When(@"I click on the sign in button")]
        public void WhenIClickOnTheSignInButton()
        {
            signInPage.ClickSignInButton();
        }

        [When(@"I enter my email address as ""([^""]*)""")]
        public void WhenIEnterMyEmailAddressAs(string email)
        {
            signInPage.EnterEmailForSignIN(email);
        }

        [When(@"I click on the create an account button")]
        public void WhenIClickOnTheCreateAnAccountButton()
        {
            signInPage.ClickCreateAccount();
        }

        [Then(@"your personal information page should display")]
        public void ThenYourPersonalInformationPageShouldDisplay()
        {
            signInPage.ValidateInformationPage();
            Console.WriteLine("Page is Displayed");

        }




        [Given(@"I click on the title button")]
        public void GivenIClickOnTheTitleButton()
        {
            signInPage.TitleButton();
        }

        [Given(@"I enter my Firstname and LastName")]
        public void GivenIEnterMyFirstnameAndLastName()
        {
            signInPage.FNameAndLName();
        }

        [When(@"I enter my password")]
        public void WhenIEnterMyPassword()
        {
            signInPage.Password();
        }

        [When(@"I select my date of birth")]
        public void WhenISelectMyDateOfBirth()
        {
            signInPage.Day();
            signInPage.Month();
            signInPage.Year();
        }


        [Given(@"I enter my address fields and values as shown below")]
        public void GivenIEnterMyAddressFieldsAndValuesAsShownBelow(Table table)
        {
            signInPage.EnterAddressDetails(table);
        }

        [Given(@"I click on register button")]
        public void GivenIClickOnRegisterButton()
        {
          signInPage.regButton();
        }

        [Then(@"I should be registered")]
        public void ThenIShouldBeRegistered()
        {
          
        }

    }
}

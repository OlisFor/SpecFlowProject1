using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class loginsteps
    {
        loginpage LoginPage;
        public loginsteps()
        {
            LoginPage = new loginpage();
        }


        [Given(@"I navigate to the URL")]
        public void GivenINavigateToTheURL(string url)
        {
            LoginPage.Launchurl(url);
        }

        [When(@"I enter the <""([^""]*)""> and <""([^""]*)"">")]
        public void WhenIEnterTheAnd(string username, string password)
        {
            LoginPage.EnterUsernameEnterpassword(username, password);
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            LoginPage.signinButton();
        }

        [Then(@"I should be logged in to the application")]
        public void ThenIShouldBeLoggedInToTheApplication()
        {
           
        }


    }
}

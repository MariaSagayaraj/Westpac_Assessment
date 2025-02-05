﻿using TechTalk.SpecFlow;
using Westpac_Assessment.Base;
using Westpac_Assessment.Pages;
using Westpac_Assessment.Helpers;
using System.Threading;

namespace Westpac_Assessment.Steps
{
    [Binding]
    public class LoginSteps : Page_Login
    {
        [Given(@"I open browser and navigate to the url")]
        public void GivenIOpenBrowserAndNavigateToTheUrl()
        {
            BaseClass init = new BaseClass();
            init.Initialize();
        }
        
        [When(@"I enter (.*) login credentials and click login button")]
        public void WhenIEnterLoginCredentialsAndClickLoginButton(string data)
        {
            Login(data);
        }

        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            WaitHelpers.TurnOnWait();
            LogoutButton.Click();
        }

        [Then(@"I validate successfull login to the application as per the (.*),(.*)")]
        public void ThenIValidateSuccessfullLoginToTheApplicationAsPerThe(string data, string name)
        {
            Assertion(data);
            Drivers.SaveScreenshot(name);
            Drivers. CloseBrowser();
        }

        [Then(@"I should be successfully logged out from the application (.*)")]
        public void ThenIShouldBeSuccessfullyLoggedOutFromTheApplication(string name)
        {
            LogOutAssertion();
            Drivers.SaveScreenshot(name);
            Drivers.CloseBrowser();
        }

    }
}

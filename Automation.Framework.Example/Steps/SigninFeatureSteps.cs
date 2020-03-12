using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Example.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using Unity;

namespace Automation.Framework.Example.Steps
{
    [Binding]
    public class SigninFeatureSteps
    {
        public LandingPage _landingPage = UnityContainerFactory.GetContainer().Resolve<LandingPage>();
        public SignInPage _signInPage = UnityContainerFactory.GetContainer().Resolve<SignInPage>();

        [Given(@"I am on BBC Landing page")]
        public void GivenIAmOnBBCLandingPage()
        {
            //pageobject.helper.helperType.method
            _landingPage.Helper.BrowserHelper.Navigate(_landingPage.LandingPageUrl);
            _landingPage.Helper.BrowserHelper.BrowserMaximise();
        }

        [When(@"I click on sign in button")]
        public void WhenIClickOnSignInButton()
        { 
            _landingPage.Helper.ButtonHelper.ClickButton(_landingPage.SignInButton_WebElement);
            Thread.Sleep(2500);
        }

        [Then(@"I am navigated to BBC sign in page")]
        public void ThenIAmNavigatedToBBCSignInPage()
        {
            _signInPage.Helper.BrowserHelper.GetBrowserUrl().Should().Contain(_signInPage.signInPageUrl);

            //hard coding the test data, only for demo purpose
            _signInPage.Helper.TextBoxHelper.TypeInTextBox(_signInPage.UserName_TextBoxWebElement, "TestUserName");
            _signInPage.Helper.TextBoxHelper.TypeInTextBox(_signInPage.Paswword_TextBoxWebElement, "Testpassword");

            _signInPage.Helper.ButtonHelper.ClickButton(_signInPage.SignIn_ButtonWebElement);
        }
    }
}
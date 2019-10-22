using Automation.Framework.Base;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Example.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver):base(driver)
        {
        }

        public string signInPageUrl = "https://account.bbc.com/signin";

        public IWebElement UserName_TextBoxWebElement => WaitTillElementDisplayed("/html//input[@id='user-identifier-input']");

        public IWebElement Paswword_TextBoxWebElement => WaitTillElementDisplayed("/html//input[@id='password-input']");

        public IWebElement SignIn_ButtonWebElement => WaitTillElementDisplayed("submit-button", ElementLocator.ID, 10);

        public IWebElement RegisterNow_LinkWebElement => WaitTillElementDisplayed("Register now",ElementLocator.PartialLinkText);

        public IWebElement NeedHelpSignIn_LinkWebElement => WaitTillElementDisplayed("Need help signing in?",ElementLocator.LinkText);
    }
}

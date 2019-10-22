using Automation.Framework.Base;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Example.Pages
{
    public class LandingPage :BasePage
    {
        public LandingPage(IWebDriver driver):base(driver)
        {
        }

        public string LandingPageUrl = "https://www.bbc.co.uk";
                                                                                //locator string, locator stratergy , seconds to wait 
        public IWebElement SignInButton_WebElement => WaitTillElementDisplayed("/html//span[@id='idcta-username']", ElementLocator.Xpath, 10);


    }
}

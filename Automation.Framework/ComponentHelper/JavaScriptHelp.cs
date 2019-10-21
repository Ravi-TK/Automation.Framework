using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class JavascriptHelp : IJavaScriptPopUpHelper
    {
        public void ClickCancelOnPopup()
        {
            Driver.Browser.SwitchTo().Alert().Dismiss();
        }

        public void ClickOkOnPopup()
        {
            Driver.Browser.SwitchTo().Alert().Accept();
        }

        public string GetPopUpText()
        {
            if (!IsPopUpPresent())
                return "Warning : No Pop Up Present";
            else
                return Driver.Browser.SwitchTo().Alert().Text;
        }

        public bool IsPopUpPresent()
        {
            try
            {
                Driver.Browser.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public void ScrollToElement(IWebElement ele)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        public void TypeTextInPopUp(string inputText)
        {
            Driver.Browser.SwitchTo().Alert().SendKeys(inputText);
        }
    }
}

using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class JavascriptHelp : IJavaScriptPopUpHelper
    {
        /// <summary>
        /// Clicks cancel button on the pop up in the browser
        /// </summary>
        public void ClickCancelOnPopup()
        {
            Driver.Browser.SwitchTo().Alert().Dismiss();
        }

        /// <summary>
        /// Clicks Ok button on the pop up in the browser
        /// </summary>
        public void ClickOkOnPopup()
        {
            Driver.Browser.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// Retrieves text displayed in the pop up in the browser
        /// </summary>
        /// <returns>Text in the pop up </returns>
        public string GetPopUpText()
        {
            if (!IsPopUpPresent())
                return "Warning : No Pop Up Present";
            else
                return Driver.Browser.SwitchTo().Alert().Text;
        }

        /// <summary>
        /// Determines if the pop up is present in the browser 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Scroll to specified WebElement
        /// </summary>
        /// <param name="ele">WebElement to focus</param>
        public void ScrollToElement(IWebElement ele)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        /// <summary>
        /// Enters specified text in the pop up in the browser
        /// </summary>
        /// <param name="inputText">Text to be displayed in the pop up </param>
        public void TypeTextInPopUp(string inputText)
        {
            Driver.Browser.SwitchTo().Alert().SendKeys(inputText);
        }
    }
}
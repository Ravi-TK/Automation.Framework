using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IJavaScriptPopUpHelper
    {
        bool IsPopUpPresent();

        string GetPopUpText();

        void ClickOkOnPopup();

        void ClickCancelOnPopup();

        void ScrollToElement(IWebElement ele);

        void TypeTextInPopUp(string inputText);
    }
}
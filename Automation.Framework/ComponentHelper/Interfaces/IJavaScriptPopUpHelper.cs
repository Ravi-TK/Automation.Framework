using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IJavaScriptPopUpHelper
    {
        bool IsPopUpPresent();
        string GetPopUpText();
        void ClickOkOnPopup();
        void ClickCancelOnPopup();
        void ScrollToElement(IWebElement ele);
        void TypeTextInPopUp(string inputText);
    }
}

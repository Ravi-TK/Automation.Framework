using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IButtonHelper
    {
        bool IsButtonEnabled(IWebElement element);
        void ClickButton(IWebElement element);
        string GetButtonText(IWebElement element);
    }
}

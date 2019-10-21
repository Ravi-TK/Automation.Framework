using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface ILabelHelpers
    {
        bool IsLabelEnabled(IWebElement element);
        string GetLabelText(IWebElement element);
        void ClickOnLabel(IWebElement element);
    }
}

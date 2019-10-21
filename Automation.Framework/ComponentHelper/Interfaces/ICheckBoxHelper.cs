using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface ICheckBoxHelper
    {
        void ClickCheckBox(IWebElement element);
        bool IsCheckboxChecked(IWebElement element);
        bool IsCheckboxEnbaled(IWebElement element);
    }
}

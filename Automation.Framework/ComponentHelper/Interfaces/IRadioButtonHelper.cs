using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IRadioButtonHelper
    {
        bool IsRadioButtonSelected(IWebElement element);
        bool IsRadioButtonEnabled(IWebElement element);
        void ClickOnRadioButton(IWebElement element);

    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface ITextBoxHelper
    {
        bool IsTextBoxEnabled(IWebElement element);
        void TypeInTextBox(IWebElement element, string text);
        string GetTextBoxText(IWebElement element);
        void ClearTextBoxText(IWebElement element);

    }
}

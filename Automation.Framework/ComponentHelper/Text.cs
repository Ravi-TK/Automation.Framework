using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class Text : ITextBoxHelper
    {
        public void ClearTextBoxText(IWebElement element)
        {
            element.Clear();
        }

        public string GetTextBoxText(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Text;
        }

        public bool IsTextBoxEnabled(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Enabled;
        }

        public void TypeInTextBox(IWebElement element, string text)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.SendKeys(text);
        }
    }
}

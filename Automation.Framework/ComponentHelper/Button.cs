using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class Button : IButtonHelper
    {
        public void ClickButton(IWebElement element)
        {
            element.Click();
        }

        public string GetButtonText(IWebElement element)
        {
            return element.Text;
        }

        public bool IsButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}

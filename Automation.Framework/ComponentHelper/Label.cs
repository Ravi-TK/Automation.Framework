using System;
using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;


namespace Automation.Framework.ComponentHelper
{
    public class Label : ILabelHelpers
    {
        public void ClickOnLabel(IWebElement element)
        {
            element.Click();
        }

        public string GetLabelText(IWebElement element)
        {
            return element.Text;
        }

        public bool IsLabelEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}

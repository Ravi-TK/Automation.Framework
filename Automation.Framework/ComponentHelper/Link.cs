using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class Link : ILinkHelper
    {
        public void ClickOnLink(IWebElement element)
        {
            element.Click();
        }

        public string GetLinkText(IWebElement element)
        {
            return element.Text;
        }

        public bool IsLinkEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}

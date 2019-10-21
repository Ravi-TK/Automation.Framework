using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface ILinkHelper
    {
        bool IsLinkEnabled(IWebElement element);
        string GetLinkText(IWebElement element);
        void ClickOnLink(IWebElement element);

    }
}

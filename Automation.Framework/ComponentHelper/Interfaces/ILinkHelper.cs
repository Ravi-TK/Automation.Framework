using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface ILinkHelper
    {
        bool IsLinkEnabled(IWebElement element);

        string GetLinkText(IWebElement element);

        void ClickOnLink(IWebElement element);
    }
}
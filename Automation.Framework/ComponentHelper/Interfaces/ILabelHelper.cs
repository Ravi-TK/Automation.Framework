using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface ILabelHelpers
    {
        bool IsLabelEnabled(IWebElement element);

        string GetLabelText(IWebElement element);

        void ClickOnLabel(IWebElement element);
    }
}
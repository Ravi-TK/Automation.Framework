using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IButtonHelper
    {
        bool IsButtonEnabled(IWebElement element);

        void ClickButton(IWebElement element);

        string GetButtonText(IWebElement element);
    }
}
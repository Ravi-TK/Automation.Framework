using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface ICheckBoxHelper
    {
        void ClickCheckBox(IWebElement element);

        bool IsCheckboxChecked(IWebElement element);

        bool IsCheckboxEnbaled(IWebElement element);
    }
}
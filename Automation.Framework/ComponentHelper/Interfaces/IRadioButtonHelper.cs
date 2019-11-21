using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IRadioButtonHelper
    {
        bool IsRadioButtonSelected(IWebElement element);

        bool IsRadioButtonEnabled(IWebElement element);

        void ClickOnRadioButton(IWebElement element);
    }
}
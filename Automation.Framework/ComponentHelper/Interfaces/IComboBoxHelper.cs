using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IComboBoxHelper
    {
        void SelectElementByIndex(IWebElement element, int index);

        void SelectElementByValue(IWebElement element, string value);

        void SelectElementByVIsibleText(IWebElement element, string visibleText);

        bool IsComboBoxEnabled(IWebElement element);
    }
}
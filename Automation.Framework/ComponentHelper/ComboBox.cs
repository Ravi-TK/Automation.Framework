using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.ComponentHelper
{
    public class ComboBox : IComboBoxHelper
    {
        private static SelectElement select;

        public bool IsComboBoxEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public void SelectElementByIndex(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public void SelectElementByValue(IWebElement element, string value)
        {
            select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public void SelectElementByVIsibleText(IWebElement element, string visibleText)
        {
            select = new SelectElement(element);
            select.SelectByText(visibleText);
        }
    }
}
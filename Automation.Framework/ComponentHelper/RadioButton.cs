using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class RadioButton : IRadioButtonHelper
    {
        public void ClickOnRadioButton(IWebElement element)
        {
            element.Click();
        }

        public bool IsRadioButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public bool IsRadioButtonSelected(IWebElement element)
        {
            string flag = element.GetAttribute("checked");

            if (flag == null)
                return false;
            else
                return true;
        }
    }
}
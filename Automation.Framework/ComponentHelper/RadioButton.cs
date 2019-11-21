using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class RadioButton : IRadioButtonHelper
    {
        /// <summary>
        /// Clicks on specified radio button 
        /// </summary>
        /// <param name="element">Radio button WebElement</param>
        public void ClickOnRadioButton(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Determines if the radio button is enabled
        /// </summary>
        /// <param name="element">Radio button WebElement</param>
        /// <returns>Returns True if Radio button is enabled else False</returns>
        public bool IsRadioButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        /// <summary>
        /// Determines if the Radio button is already selected
        /// </summary>
        /// <param name="element">Radio button WebElement</param>
        /// <returns>Return True </returns>
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
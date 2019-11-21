using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class Button : IButtonHelper
    {
        /// <summary>
        /// Clicks on specified button
        /// </summary>
        /// <param name="element">Button WebElement</param>
        public void ClickButton(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Retrieve text displayed on specified button
        /// </summary>
        /// <param name="element">Button Welement</param>
        /// <returns>Button Text</returns>
        public string GetButtonText(IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Determines if the element is enabled or not 
        /// </summary>
        /// <param name="element">Button WebElement </param>
        /// <returns>Return True if button is enabled else False</returns>
        public bool IsButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}
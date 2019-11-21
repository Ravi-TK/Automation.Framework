using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class Label : ILabelHelpers
    {
        /// <summary>
        /// Clicks on the Label
        /// </summary>
        /// <param name="element">Label WebElement</param>
        public void ClickOnLabel(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Retrieves text of the Label
        /// </summary>
        /// <param name="element"> Label WebElement</param>
        /// <returns></returns>
        public string GetLabelText(IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Determines if label is enabled
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsLabelEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}
using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class Link : ILinkHelper
    {
        /// <summary>
        /// Clicks on Link
        /// </summary>
        /// <param name="element">Link WebElement</param>
        public void ClickOnLink(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Retrieves Link's text
        /// </summary>
        /// <param name="element">Link WebElement</param>
        /// <returns></returns>
        public string GetLinkText(IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Determines if link is enabled 
        /// </summary>
        /// <param name="element">Link's WebElement</param>
        /// <returns></returns>
        public bool IsLinkEnabled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}
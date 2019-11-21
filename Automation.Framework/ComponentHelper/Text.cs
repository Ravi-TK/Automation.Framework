using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class Text : ITextBoxHelper
    {
        /// <summary>
        /// Clears text of specified TextBox
        /// </summary>
        /// <param name="element">Textbox WebElement</param>
        public void ClearTextBoxText(IWebElement element)
        {
            element.Clear();
        }

        /// <summary>
        /// Retrieves text inside specified TextBox  
        /// </summary>
        /// <param name="element">Textbox WebElement</param>
        /// <returns></returns>
        public string GetTextBoxText(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Text;
        }

        /// <summary>
        /// Determines if TextBox is enabled
        /// </summary>
        /// <param name="element">TextBox WebElement</param>
        /// <returns>Retruns True if Textbox is enabled else False</returns>
        public bool IsTextBoxEnabled(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Enabled;
        }

        /// <summary>
        /// Enters specified text in the specified Textbox WebElement
        /// </summary>
        /// <param name="element">Textbox WebElement</param>
        /// <param name="text">Text to be enetered in the textbox</param>
        public void TypeInTextBox(IWebElement element, string text)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.SendKeys(text);
        }
    }
}
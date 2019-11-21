using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper
{
    public class CheckBox : ICheckBoxHelper
    {
        /// <summary>
        /// Clicks on specified checkbox
        /// </summary>
        /// <param name="element">Checkbox Element</param>
        public void ClickCheckBox(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Determines if checkbox is Checked
        /// </summary>
        /// <param name="element">Checkbox Element</param>
        /// <returns>Returns True if checkbox is checked else False</returns>
        public bool IsCheckboxChecked(IWebElement element)
        {
            string flag = element.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Determines if checkbox enabled
        /// </summary>
        /// <param name="element">checkbox element</param>
        /// <returns>Returns true if checkbox is enabled else False</returns>
        public bool IsCheckboxEnbaled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}
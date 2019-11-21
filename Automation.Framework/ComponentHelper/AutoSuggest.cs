using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Automation.Framework.ComponentHelper
{
    public class AutoSuggest : IAutoSuggestHelper
    {
        public void SelectItemInList(IWebElement dropDownList, string DropDownListEntriesLocator, string searchChar, string itemToClick)
        {
            //supply initial char
            dropDownList.SendKeys(searchChar);
            Thread.Sleep(2000);

            //wait for auto suggest list
            IList<IWebElement> elements = Driver.Browser.FindElements((By.XPath(DropDownListEntriesLocator)));

            foreach (var ele in elements)
            {
                if (ele.Text.Equals(itemToClick))
                {
                    ele.Click();
                    break;
                }
            }
        }
    }
}
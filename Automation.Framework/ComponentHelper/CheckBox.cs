using Automation.Framework.ComponentHelper.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class CheckBox : ICheckBoxHelper
    {
        public void ClickCheckBox(IWebElement element)
        {
            element.Click();
        }

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

        public bool IsCheckboxEnbaled(IWebElement element)
        {
            return element.Enabled;
        }
    }
}

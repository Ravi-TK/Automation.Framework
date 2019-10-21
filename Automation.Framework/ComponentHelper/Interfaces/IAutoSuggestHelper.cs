using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IAutoSuggestHelper
    {
        void SelectItemInList(IWebElement dropDownList, string DropDownListEntriesLocator, string searchChar, string itemToClick);
    }
}

using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IAutoSuggestHelper
    {
        void SelectItemInList(IWebElement dropDownList, string DropDownListEntriesLocator, string searchChar, string itemToClick);
    }
}
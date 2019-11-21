using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface ITextBoxHelper
    {
        bool IsTextBoxEnabled(IWebElement element);

        void TypeInTextBox(IWebElement element, string text);

        string GetTextBoxText(IWebElement element);

        void ClearTextBoxText(IWebElement element);
    }
}
using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class TextBoxTest
    {
        private W3schoolPage _textBoxPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void IsTextBoxEnabled()
        {
            _textBoxPage.Helper.BrowserHelper.Navigate(_textBoxPage.w3schoolTextBoxUrl);
            _textBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _textBoxPage.Helper.BrowserHelper.SwitchToFrame(_textBoxPage.demoFrameWebElement);

            bool txtEnabled = _textBoxPage.Helper.TextBoxHelper.IsTextBoxEnabled(_textBoxPage.firstNameTextboxWebelement);
            Assert.IsTrue(txtEnabled);
        }

        [TestMethod]
        public void TypeInTextBox()
        {
            _textBoxPage.Helper.BrowserHelper.Navigate(_textBoxPage.w3schoolTextBoxUrl);
            _textBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _textBoxPage.Helper.BrowserHelper.SwitchToFrame(_textBoxPage.demoFrameWebElement);

            _textBoxPage.Helper.TextBoxHelper.ClearTextBoxText(_textBoxPage.firstNameTextboxWebelement);
            _textBoxPage.Helper.TextBoxHelper.TypeInTextBox(_textBoxPage.firstNameTextboxWebelement, "Test1");

            _textBoxPage.Helper.TextBoxHelper.ClearTextBoxText(_textBoxPage.lastNameTextboxWebelement);
            _textBoxPage.Helper.TextBoxHelper.TypeInTextBox(_textBoxPage.lastNameTextboxWebelement, "Test2");

            _textBoxPage.Helper.ButtonHelper.ClickButton(_textBoxPage.submitButtonWebelement);

            string resulttxt = _textBoxPage.Helper.TextBoxHelper.GetTextBoxText(_textBoxPage.checkboxResultWebElement);
            Assert.AreEqual(resulttxt, "fname=Test1&lname=Test2 ");
        }

        [TestMethod]
        public void ClearTextBoxText()
        {
            _textBoxPage.Helper.BrowserHelper.Navigate(_textBoxPage.w3schoolTextBoxUrl);
            _textBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _textBoxPage.Helper.BrowserHelper.SwitchToFrame(_textBoxPage.demoFrameWebElement);

            _textBoxPage.Helper.TextBoxHelper.ClearTextBoxText(_textBoxPage.firstNameTextboxWebelement);
            string txt = _textBoxPage.Helper.TextBoxHelper.GetTextBoxText(_textBoxPage.firstNameTextboxWebelement);
            Assert.AreEqual(txt, "");
        }
    }
}
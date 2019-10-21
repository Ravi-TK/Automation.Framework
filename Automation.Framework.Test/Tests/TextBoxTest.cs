using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.AreEqual(resulttxt, "FirstName=Test1&LastName=Test2 ");

        }

        //[TestMethod]
        //public void GetTextBoxText()
        //{
        //    //_textBoxPage.Helper.BrowserHelper.Navigate(_textBoxPage.w3schoolTextBoxUrl);
        //    //_textBoxPage.Helper.BrowserHelper.BrowserMaximise();
        //    //_textBoxPage.Helper.BrowserHelper.SwitchToFrame(_textBoxPage.demoFrameWebElement);

        //    _textBoxPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/html/html_forms.asp");
        //    _textBoxPage.Helper.BrowserHelper.BrowserMaximise();

        //    _textBoxPage.Helper.TextBoxHelper.TypeInTextBox(Driver.Browser.FindElement(By.XPath("//div[@id='main']/input[1]")), "Test1");

        //    string txt = _textBoxPage.Helper.TextBoxHelper.GetTextBoxText(Driver.Browser.FindElement(By.XPath("//div[@id='main']/input[1]")));

        //    string txt2 = Driver.Browser.FindElement(By.XPath("//div[@id='main']/input[1]")).Text;

        //    Assert.AreEqual(txt, "Test1");

        //    //_textBoxPage.Helper.TextBoxHelper.ClearTextBoxText(_textBoxPage.firstNameTextboxWebelement);
        //    //_textBoxPage.Helper.TextBoxHelper.TypeInTextBox(_textBoxPage.firstNameTextboxWebelement, "Test1");

        //    //string txt = _textBoxPage.Helper.TextBoxHelper.GetTextBoxText(_textBoxPage.firstNameTextboxWebelement);
        //    //Assert.AreEqual(txt, "Test1");

        //}

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

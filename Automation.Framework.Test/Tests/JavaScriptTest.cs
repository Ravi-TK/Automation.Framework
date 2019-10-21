using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using System;
using System.Collections.Generic;
using System.Text;
using Automation.Framework.Base;
using Automation.Framework.Core;
using OpenQA.Selenium;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class JavaScriptTest
    {
        private W3schoolPage _javascriptPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void IsPopUpPresent()
        {
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
            bool popUpPresent = _javascriptPage.Helper.JavaScriptHelper.IsPopUpPresent();

            if (popUpPresent)
            {
                _javascriptPage.Helper.JavaScriptHelper.ClickOkOnPopup();
            }

            _javascriptPage.Helper.BrowserHelper.BrowserRefresh();
            _javascriptPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm"/*javascriptPage.w3schoolPopUpUrl*/);
            _javascriptPage.Helper.BrowserHelper.BrowserMaximise();
            _javascriptPage.Helper.BrowserHelper.SwitchToFrame(_javascriptPage.demoFrameWebElement);
            _javascriptPage.Helper.ButtonHelper.ClickButton(_javascriptPage.tryItButtonWebElement);

            popUpPresent = _javascriptPage.Helper.JavaScriptHelper.IsPopUpPresent();
            Assert.IsTrue(popUpPresent);
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void GetPopUpText()
        {
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
            _javascriptPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm"/*javascriptPage.w3schoolPopUpUrl*/);
            _javascriptPage.Helper.BrowserHelper.BrowserMaximise();
            _javascriptPage.Helper.BrowserHelper.SwitchToFrame(_javascriptPage.demoFrameWebElement);
            _javascriptPage.Helper.ButtonHelper.ClickButton(_javascriptPage.tryItButtonWebElement);

            string popUptxt = _javascriptPage.Helper.JavaScriptHelper.GetPopUpText();
            Assert.AreEqual(popUptxt, "Press a button!");
            _javascriptPage.Helper.JavaScriptHelper.ClickOkOnPopup();
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void ClickOkOnPopup()
        {
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
            _javascriptPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            _javascriptPage.Helper.BrowserHelper.BrowserMaximise();
            _javascriptPage.Helper.BrowserHelper.SwitchToFrame(_javascriptPage.demoFrameWebElement);
            _javascriptPage.Helper.ButtonHelper.ClickButton(_javascriptPage.tryItButtonWebElement);
            _javascriptPage.Helper.JavaScriptHelper.ClickOkOnPopup();

            string popUpTxt = _javascriptPage.Helper.LabelHelper.GetLabelText(_javascriptPage.popUPResultWebElement);
            Assert.AreEqual(popUpTxt, "You pressed OK!");
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void ClickCancelOnPopup()
        {
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
            _javascriptPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            _javascriptPage.Helper.BrowserHelper.BrowserMaximise();
            _javascriptPage.Helper.BrowserHelper.SwitchToFrame(_javascriptPage.demoFrameWebElement);
            _javascriptPage.Helper.ButtonHelper.ClickButton(_javascriptPage.tryItButtonWebElement);
            _javascriptPage.Helper.JavaScriptHelper.ClickCancelOnPopup();

            string popUpTxt = _javascriptPage.Helper.LabelHelper.GetLabelText(_javascriptPage.popUPResultWebElement);
            Assert.AreEqual(popUpTxt, "You pressed Cancel!");
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void TypeTextInPopUp()
        {
            _javascriptPage.Helper.BrowserHelper.SwitchToParent();

            bool popUpPresent = _javascriptPage.Helper.JavaScriptHelper.IsPopUpPresent();

            if (popUpPresent)
            {
                _javascriptPage.Helper.JavaScriptHelper.ClickOkOnPopup();
            }

            _javascriptPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            _javascriptPage.Helper.BrowserHelper.BrowserMaximise();
            _javascriptPage.Helper.BrowserHelper.SwitchToFrame(_javascriptPage.demoFrameWebElement);
            _javascriptPage.Helper.ButtonHelper.ClickButton(_javascriptPage.tryItButtonWebElement);

            Driver.Browser.SwitchTo().Alert().SendKeys("");
            _javascriptPage.Helper.JavaScriptHelper.TypeTextInPopUp("Test!");
            _javascriptPage.Helper.JavaScriptHelper.ClickOkOnPopup();

            string popUpTxt = _javascriptPage.Helper.LabelHelper.GetLabelText(_javascriptPage.popUpPromptResultWebElement);
            Assert.AreEqual(popUpTxt, "Hello Test!! How are you today?");
        }

    }
}

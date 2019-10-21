using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity;
using System.Collections.Generic;
using System.Text;
using Automation.Framework.Core;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class ButtonTest
    {
        private W3schoolPage _buttonPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void ButtonClick()
        {
            _buttonPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/tags/tag_button.asp");
            _buttonPage.Helper.ButtonHelper.ClickButton(_buttonPage.TryItURselfButtonWebElement);
            _buttonPage.Helper.BrowserHelper.SwitchToWindow(1);
            Assert.AreEqual(_buttonPage.tryItUrSelfPageUrl, _buttonPage.Helper.BrowserHelper.GetBrowserUrl(),"Button Click event failed");
            Driver.Browser.Close();
            _buttonPage.Helper.BrowserHelper.SwitchToWindow(0);

        }

        [TestMethod]
        public void ButtonText()
        {
            _buttonPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/tags/tag_button.asp");
            string buttonText = _buttonPage.Helper.ButtonHelper.GetButtonText(_buttonPage.TryItURselfButtonWebElement);
            Assert.AreEqual("Try it Yourself »", buttonText,"Get Button Text event failed");
        }

        [TestMethod]
        public void ButtonEnabled()
        {
            _buttonPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/tags/tag_button.asp");
            bool buttonEnabled = _buttonPage.Helper.ButtonHelper.IsButtonEnabled(_buttonPage.TryItURselfButtonWebElement);
            Assert.IsTrue(buttonEnabled);
        }





    }
}

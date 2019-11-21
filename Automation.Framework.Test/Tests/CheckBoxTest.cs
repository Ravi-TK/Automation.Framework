using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class CheckBoxTest
    {
        private W3schoolPage _checkBoxPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void checkboxClick()
        {
            _checkBoxPage.Helper.BrowserHelper.Navigate(_checkBoxPage.tryItUrSelfCheckboxUrl);
            _checkBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _checkBoxPage.Helper.ButtonHelper.ClickButton(_checkBoxPage.TryItURselfcheckboxButtonWebElement);
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _checkBoxPage.Helper.BrowserHelper.SwitchToFrame(_checkBoxPage.demoFrameWebElement);
            _checkBoxPage.Helper.CheckBoxHelper.ClickCheckBox(_checkBoxPage.checkboxCarWebElement);
            _checkBoxPage.Helper.ButtonHelper.ClickButton(_checkBoxPage.submitButtonWebelement);
            string result = _checkBoxPage.Helper.TextBoxHelper.GetTextBoxText(_checkBoxPage.checkboxResultWebElement);
            Assert.IsTrue(result.Contains("Car"));
            Driver.Browser.Close();
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(0);
        }

        [TestMethod]
        public void checkboxText()
        {
            //_checkBoxPage.Helper.BrowserHelper.Navigate(_checkBoxPage.tryItUrSelfCheckboxUrl);
            //_checkBoxPage.Helper.BrowserHelper.BrowserMaximise();
            //_checkBoxPage.Helper.ButtonHelper.ClickButton(_checkBoxPage.TryItURselfcheckboxButtonWebElement);
            //_checkBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            //_checkBoxPage.Helper.BrowserHelper.SwitchToFrame(_checkBoxPage.demoFrameWebElement);
            //string chkTxt = _checkBoxPage.Helper.CheckBoxHelper.GetCheckboxText(_checkBoxPage.checkboxCarWebElement);
            //Assert.AreEqual(chkTxt, " I have a car");
            //Driver.Browser.Close();
            //_checkBoxPage.Helper.BrowserHelper.SwitchToWindow(0);
        }

        [TestMethod]
        public void checkboxChecked()
        {
            _checkBoxPage.Helper.BrowserHelper.Navigate(_checkBoxPage.tryItUrSelfCheckboxUrl);
            _checkBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _checkBoxPage.Helper.ButtonHelper.ClickButton(_checkBoxPage.TryItURselfcheckboxButtonWebElement);
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _checkBoxPage.Helper.BrowserHelper.SwitchToFrame(_checkBoxPage.demoFrameWebElement);
            _checkBoxPage.Helper.CheckBoxHelper.ClickCheckBox(_checkBoxPage.checkboxCarWebElement);
            bool chkchecked = _checkBoxPage.Helper.CheckBoxHelper.IsCheckboxChecked(_checkBoxPage.checkboxCarWebElement);
            Assert.IsTrue(chkchecked);
            Driver.Browser.Close();
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(0);
        }

        [TestMethod]
        public void checkboxEnaled()
        {
            _checkBoxPage.Helper.BrowserHelper.Navigate(_checkBoxPage.tryItUrSelfCheckboxUrl);
            _checkBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _checkBoxPage.Helper.ButtonHelper.ClickButton(_checkBoxPage.TryItURselfcheckboxButtonWebElement);
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _checkBoxPage.Helper.BrowserHelper.SwitchToFrame(_checkBoxPage.demoFrameWebElement);
            bool chkenabled = _checkBoxPage.Helper.CheckBoxHelper.IsCheckboxEnbaled(_checkBoxPage.checkboxCarWebElement);
            Assert.IsTrue(chkenabled);
            Driver.Browser.Close();
            _checkBoxPage.Helper.BrowserHelper.SwitchToWindow(0);
        }
    }
}
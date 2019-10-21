using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class RadioButtonTest
    {
        private W3schoolPage _radioButtonPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void IsRadioButtonSelected()
        {
            _radioButtonPage.Helper.BrowserHelper.Navigate(_radioButtonPage.w3schoolRadioButtonUrl);
            _radioButtonPage.Helper.BrowserHelper.BrowserMaximise();
            _radioButtonPage.Helper.BrowserHelper.SwitchToFrame(_radioButtonPage.demoFrameWebElement);

            _radioButtonPage.Helper.RadioButtonHelper.ClickOnRadioButton(_radioButtonPage.FemaleRadioButtonWebElement);

            bool buttonSelected = _radioButtonPage.Helper.RadioButtonHelper.IsRadioButtonSelected(_radioButtonPage.FemaleRadioButtonWebElement);
            Assert.IsTrue(buttonSelected);
        }

        [TestMethod]
        public void IsRadioButtonEnabled()
        {
            _radioButtonPage.Helper.BrowserHelper.Navigate(_radioButtonPage.w3schoolRadioButtonUrl);
            _radioButtonPage.Helper.BrowserHelper.BrowserMaximise();
            _radioButtonPage.Helper.BrowserHelper.SwitchToFrame(_radioButtonPage.demoFrameWebElement);

            bool buttonEnabled =_radioButtonPage.Helper.RadioButtonHelper.IsRadioButtonEnabled(_radioButtonPage.FemaleRadioButtonWebElement);
            Assert.IsTrue(buttonEnabled);
        }

        [TestMethod]
        public void ClickOnRadioButton()
        {
            _radioButtonPage.Helper.BrowserHelper.Navigate(_radioButtonPage.w3schoolRadioButtonUrl);
            _radioButtonPage.Helper.BrowserHelper.BrowserMaximise();
            _radioButtonPage.Helper.BrowserHelper.SwitchToFrame(_radioButtonPage.demoFrameWebElement);

           _radioButtonPage.Helper.RadioButtonHelper.ClickOnRadioButton(_radioButtonPage.FemaleRadioButtonWebElement);
           _radioButtonPage.Helper.RadioButtonHelper.ClickOnRadioButton(_radioButtonPage.Age30RadioButtonWebElement);

           _radioButtonPage.Helper.ButtonHelper.ClickButton(_radioButtonPage.radioButtonSubmitWebelement);
           string txt = _radioButtonPage.Helper.TextBoxHelper.GetTextBoxText(_radioButtonPage.radioButtonResulttxtWebElement);
            Assert.AreEqual(txt, "gender=female&age=30 ");
        }

    }
}

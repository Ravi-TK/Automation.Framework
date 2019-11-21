using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class LabelTest
    {
        private W3schoolPage _labelPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void IsLabelEnabled()
        {
            _labelPage.Helper.BrowserHelper.Navigate(_labelPage.w3schoolLabelUrl);
            _labelPage.Helper.BrowserHelper.BrowserMaximise();
            _labelPage.Helper.BrowserHelper.SwitchToFrame(_labelPage.demoFrameWebElement);

            bool labelEnabled = _labelPage.Helper.LabelHelper.IsLabelEnabled(_labelPage.OtherLabelwebElement);
            Assert.IsTrue(labelEnabled);
        }

        [TestMethod]
        public void GetLabelText()
        {
            _labelPage.Helper.BrowserHelper.Navigate(_labelPage.w3schoolLabelUrl);
            _labelPage.Helper.BrowserHelper.BrowserMaximise();
            _labelPage.Helper.BrowserHelper.SwitchToFrame(_labelPage.demoFrameWebElement);

            string labelTxt = _labelPage.Helper.LabelHelper.GetLabelText(_labelPage.OtherLabelwebElement);
            Assert.AreEqual(labelTxt, "Other");
        }

        [TestMethod]
        public void ClickOnLabel()
        {
            _labelPage.Helper.BrowserHelper.Navigate(_labelPage.w3schoolLabelUrl);
            _labelPage.Helper.BrowserHelper.BrowserMaximise();
            _labelPage.Helper.BrowserHelper.SwitchToFrame(_labelPage.demoFrameWebElement);

            _labelPage.Helper.LabelHelper.ClickOnLabel(_labelPage.OtherLabelwebElement);
            bool labelSelected = _labelPage.Helper.CheckBoxHelper.IsCheckboxChecked(_labelPage.OtherLabelChkWebElement);
            Assert.IsTrue(labelSelected);
        }
    }
}
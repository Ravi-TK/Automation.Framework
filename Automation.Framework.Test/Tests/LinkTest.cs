using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using System;
using System.Collections.Generic;
using System.Text;
using Automation.Framework.Base;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class LinkTest
    {
        private W3schoolPage _linkPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void IsLinkEnabled()
        {
            _linkPage.Helper.BrowserHelper.Navigate(_linkPage.w3schoolLinkUrl);
            _linkPage.Helper.BrowserHelper.BrowserMaximise();
            _linkPage.Helper.BrowserHelper.SwitchToFrame(_linkPage.demoFrameWebElement);

            bool linkEnabled = _linkPage.Helper.LinkHelper.IsLinkEnabled(_linkPage.linkWebElement);
            Assert.IsTrue(linkEnabled);
        }

        [TestMethod]
        public void GetLinkText()
        {
            _linkPage.Helper.BrowserHelper.Navigate(_linkPage.w3schoolLinkUrl);
            _linkPage.Helper.BrowserHelper.BrowserMaximise();
            _linkPage.Helper.BrowserHelper.SwitchToFrame(_linkPage.demoFrameWebElement);

            string linkTxt = _linkPage.Helper.LinkHelper.GetLinkText(_linkPage.linkWebElement);
            Assert.AreEqual(linkTxt, "Visit our HTML tutorial");
        }

        [TestMethod]
        public void ClickOnLink()
        {
            _linkPage.Helper.BrowserHelper.Navigate(_linkPage.w3schoolLinkUrl);
            _linkPage.Helper.BrowserHelper.BrowserMaximise();
            _linkPage.Helper.BrowserHelper.SwitchToFrame(_linkPage.demoFrameWebElement);

            _linkPage.Helper.LinkHelper.ClickOnLink(_linkPage.linkWebElement);
            bool linkClikced = _linkPage.titleAferLinkCLickedWebElement.Displayed;
            Assert.IsTrue(linkClikced);
        }

    }
}

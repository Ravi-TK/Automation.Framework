using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using System;
using System.Collections.Generic;
using System.Text;
using Automation.Framework.Base;
using Automation.Framework.Core;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class BrowserTest
    {

        private W3schoolPage _browserPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void MoveForward()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.w3schoolHtmlDemoUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.NextButtonWebElement);
            _browserPage.Helper.BrowserHelper.MoveBackward();
            _browserPage.Helper.BrowserHelper.MoveForward();
            string url = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(url, "https://www.w3schools.com/html/html_intro.asp");
        }

        [TestMethod]
        public void MoveBackward()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.w3schoolHtmlDemoUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.NextButtonWebElement);
            _browserPage.Helper.BrowserHelper.MoveBackward();
            _browserPage.Helper.BrowserHelper.MoveForward();
            _browserPage.Helper.BrowserHelper.MoveBackward();
            string url = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(url, "https://www.w3schools.com/html/default.asp");
        }

        [TestMethod]
        public void Navigate()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.w3schoolHtmlDemoUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            string browserUrl = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(browserUrl, _browserPage.w3schoolHtmlDemoUrl);
        }

        [TestMethod]
        public void GetBrowserTitle()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.w3schoolHtmlDemoUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            string browserTitle = _browserPage.Helper.BrowserHelper.GetBrowserTitle();
            Assert.AreEqual(browserTitle, "HTML Tutorial");

        }

        [TestMethod]
        public void GetBrowserUrl()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.w3schoolHtmlDemoUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.NextButtonWebElement);
            string browserurl = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(browserurl, "https://www.w3schools.com/html/html_intro.asp");

        }

        [TestMethod]
        public void SwitchToWindow()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.tryItUrSelfBrowserUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.TryItURselfBrowserButtonWebElement);
            _browserPage.Helper.BrowserHelper.SwitchToWindow(1);
            string browserurl = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(browserurl, "https://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_win_open");
            Driver.Browser.Close();
            _browserPage.Helper.BrowserHelper.SwitchToWindow(0);
        }

        [TestMethod]
        public void SwitchToParent()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.tryItUrSelfBrowserUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.TryItURselfBrowserButtonWebElement);
            _browserPage.Helper.BrowserHelper.SwitchToWindow(1);
            _browserPage.Helper.BrowserHelper.SwitchToFrame(_browserPage.demoFrameWebElement);
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.tryItButtonWebElement);
            _browserPage.Helper.BrowserHelper.SwitchToWindow(2);
            _browserPage.Helper.BrowserHelper.SwitchToParent();
            string url = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(url, "https://www.w3schools.com/jsref/met_win_open.asp");

        }

        [TestMethod]
        public void SwitchToFrame()
        {
            _browserPage.Helper.BrowserHelper.Navigate(_browserPage.tryItUrSelfBrowserUrl);
            _browserPage.Helper.BrowserHelper.BrowserMaximise();
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.TryItURselfBrowserButtonWebElement);
            _browserPage.Helper.BrowserHelper.SwitchToWindow(1);
            _browserPage.Helper.BrowserHelper.SwitchToFrame(_browserPage.demoFrameWebElement);
            _browserPage.Helper.ButtonHelper.ClickButton(_browserPage.tryItButtonWebElement);
            _browserPage.Helper.BrowserHelper.SwitchToWindow(2);
            string url = _browserPage.Helper.BrowserHelper.GetBrowserUrl();
            Assert.AreEqual(url, "https://www.w3schools.com/");

            Driver.Browser.Close();
            _browserPage.Helper.BrowserHelper.SwitchToWindow(1);
            Driver.Browser.Close();
            _browserPage.Helper.BrowserHelper.SwitchToWindow(0);
        }

    }
}

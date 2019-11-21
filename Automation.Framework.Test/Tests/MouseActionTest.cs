using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class MouseActionTest
    {
        private W3schoolPage _mouseActionPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void DragNDrop()
        {
            _mouseActionPage.Helper.BrowserHelper.Navigate("https://demos.telerik.com/kendo-ui/dragdrop/events");
            _mouseActionPage.Helper.BrowserHelper.BrowserMaximise();
            IWebElement src = Driver.Browser.FindElement(By.Id("draggable"));
            IWebElement tar = Driver.Browser.FindElement(By.Id("droptarget"));

            _mouseActionPage.Helper.MouseActionHelper.DragNDrop(src, tar);
            string txt = _mouseActionPage.Helper.LabelHelper.GetLabelText(tar);
            Assert.AreEqual(txt, "You did great!");
        }

        [TestMethod]
        public void ClickNHoldNDrop()
        {
            _mouseActionPage.Helper.BrowserHelper.Navigate("http://demos.telerik.com/kendo-ui/sortable/index");
            _mouseActionPage.Helper.BrowserHelper.BrowserMaximise();
            IWebElement ele = Driver.Browser.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            IWebElement tar = Driver.Browser.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]/span"));

            _mouseActionPage.Helper.MouseActionHelper.ClickNHoldNDrop(ele, tar);

            string txt = _mouseActionPage.Helper.LabelHelper.GetLabelText(Driver.Browser.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]")));
            Assert.AreEqual(txt, "One Step Closer\r\n2:35");
        }

        [TestMethod]
        public void DoubleClickOnElement()
        {
            _mouseActionPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/jquery/tryit.asp?filename=tryjquery_event_dblclick");
            _mouseActionPage.Helper.BrowserHelper.BrowserMaximise();
            _mouseActionPage.Helper.BrowserHelper.SwitchToFrame(_mouseActionPage.demoFrameWebElement);
            IWebElement doubleClickPara = Driver.Browser.FindElement(By.XPath("/html//p[.='Double-click on this paragraph.']"));

            _mouseActionPage.Helper.MouseActionHelper.DoubleClickOnElement(doubleClickPara);
            Assert.IsTrue(_mouseActionPage.Helper.JavaScriptHelper.IsPopUpPresent());
            string txt = _mouseActionPage.Helper.JavaScriptHelper.GetPopUpText();
            Assert.AreEqual(txt, "The paragraph was double-clicked.");
            _mouseActionPage.Helper.JavaScriptHelper.ClickOkOnPopup();
        }
    }
}
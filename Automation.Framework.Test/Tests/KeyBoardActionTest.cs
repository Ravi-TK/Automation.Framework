using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class KeyBoardActionTest
    {
        private W3schoolPage _KeyBoardActionPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        //[TestMethod]
        public void SingleCommandKeyAction()
        {
            _KeyBoardActionPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/");
            _KeyBoardActionPage.Helper.BrowserHelper.BrowserMaximise();

            _KeyBoardActionPage.Helper.KeyBoardActionHelper.SingleCommandKeyAction(Keys.LeftControl, "t");
            _KeyBoardActionPage.Helper.BrowserHelper.SwitchToWindow(1);
        }

        public void DoubleCommandKeyAction()
        {
            _KeyBoardActionPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/");
            _KeyBoardActionPage.Helper.BrowserHelper.BrowserMaximise();
        }

        public void SingleCommandKeyAction2()
        {
        }
    }
}
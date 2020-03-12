using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

           // string selectall= Keys.
            //Driver.Browser.FindElement
            //    (By.XPath("/html/body/div[1]/div[2]/div[@class='w3-right']"))
            //    .SendKeys(Keys.Control + "a");

            //Actions act = new Actions(Driver.Browser);

            //act.KeyDown(Keys.Control)
            //    .SendKeys("T")
            //    .KeyUp(Keys.Control)
            //    .Build()
            //    .Perform();


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
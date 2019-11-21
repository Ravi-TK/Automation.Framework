using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class AutoSuggestTest
    {
        private W3schoolPage _AutoSuggestPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void SelectItemInList()
        {
            _AutoSuggestPage.Helper.BrowserHelper.Navigate("https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_autocomplete");

            _AutoSuggestPage.Helper.BrowserHelper.BrowserMaximise();
            _AutoSuggestPage.Helper.BrowserHelper.SwitchToFrame(_AutoSuggestPage.demoFrameWebElement);

            IWebElement dropdown = Driver.Browser.FindElement(By.XPath("/html//input[@id='myInput']"));

            _AutoSuggestPage.Helper.AutoSuggestHelper.SelectItemInList(dropdown, "//div[@id='myInputautocomplete-list']/div", "U", "Uruguay");
            _AutoSuggestPage.Helper.ButtonHelper.ClickButton(Driver.Browser.FindElement(By.XPath("//form[@action='/action_page.php']/input[@type='submit']")));

            Thread.Sleep(2000);
            string txt = _AutoSuggestPage.Helper.TextBoxHelper.GetTextBoxText(Driver.Browser.FindElement(By.XPath("//body[@class='w3-container']/div[1]")));
            Assert.AreEqual(txt, "myCountry=Uruguay ");
        }
    }
}
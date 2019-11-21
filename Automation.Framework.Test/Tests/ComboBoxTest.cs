using Automation.Framework.Base;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Automation.Framework.Test.Tests
{
    [TestClass]
    public class ComboBoxTest
    {
        private W3schoolPage _comboBoxPage = UnityContainerFactory.GetContainer().Resolve<W3schoolPage>();

        [TestMethod]
        public void SelectElementByIndex()
        {
            _comboBoxPage.Helper.BrowserHelper.Navigate(_comboBoxPage.w3schoolComboboxUrl);
            _comboBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _comboBoxPage.Helper.ButtonHelper.ClickButton(_comboBoxPage.TryItURselfComboBoxButtonWebElement);
            _comboBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _comboBoxPage.Helper.BrowserHelper.SwitchToFrame(_comboBoxPage.demoFrameWebElement);

            _comboBoxPage.Helper.ComboBoxHelper.SelectElementByIndex(_comboBoxPage.comoboBoxWebElement, 2);
            _comboBoxPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void SelectElementByValue()
        {
            _comboBoxPage.Helper.BrowserHelper.Navigate(_comboBoxPage.w3schoolComboboxUrl);
            _comboBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _comboBoxPage.Helper.ButtonHelper.ClickButton(_comboBoxPage.TryItURselfComboBoxButtonWebElement);
            _comboBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _comboBoxPage.Helper.BrowserHelper.SwitchToFrame(_comboBoxPage.demoFrameWebElement);

            _comboBoxPage.Helper.ComboBoxHelper.SelectElementByValue(_comboBoxPage.comoboBoxWebElement, "saab");
            _comboBoxPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void SelectElementByVIsibleText()
        {
            _comboBoxPage.Helper.BrowserHelper.Navigate(_comboBoxPage.w3schoolComboboxUrl);
            _comboBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _comboBoxPage.Helper.ButtonHelper.ClickButton(_comboBoxPage.TryItURselfComboBoxButtonWebElement);
            _comboBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _comboBoxPage.Helper.BrowserHelper.SwitchToFrame(_comboBoxPage.demoFrameWebElement);

            _comboBoxPage.Helper.ComboBoxHelper.SelectElementByVIsibleText(_comboBoxPage.comoboBoxWebElement, "Audi");
            _comboBoxPage.Helper.BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void IsComboBoxEnabled()
        {
            _comboBoxPage.Helper.BrowserHelper.Navigate(_comboBoxPage.w3schoolComboboxUrl);
            _comboBoxPage.Helper.BrowserHelper.BrowserMaximise();
            _comboBoxPage.Helper.ButtonHelper.ClickButton(_comboBoxPage.TryItURselfComboBoxButtonWebElement);
            _comboBoxPage.Helper.BrowserHelper.SwitchToWindow(1);
            _comboBoxPage.Helper.BrowserHelper.SwitchToFrame(_comboBoxPage.demoFrameWebElement);

            bool cmbBoxenabled = _comboBoxPage.Helper.ComboBoxHelper.IsComboBoxEnabled(_comboBoxPage.comoboBoxWebElement);
            Assert.IsTrue(cmbBoxenabled);
            _comboBoxPage.Helper.BrowserHelper.SwitchToParent();
        }
    }
}
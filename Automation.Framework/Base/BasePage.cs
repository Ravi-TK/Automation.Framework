using Automation.Framework.ComponentHelper;
using Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Automation.Framework.Base
{
    public class BasePage
    {
        /// <summary>
        /// Helper Componnents object
        /// </summary>
        public Helpers Helper = new Helpers();
        private static IWebElement _webElement;

        public BasePage(IWebDriver driver)
        {
            Driver.Browser = driver;
        }

        /// <summary>
        /// Create a instance of Selenium webElement
        /// </summary>
        /// <param name="locator">Locator path</param>
        /// <param name="elementLocatorType"> Locator Type i.e. Xpath,Id,etc.</param>
        /// <param name="TimeOutForFindingElement"> Number of seconds an element should wait for a webelement to display or exists </param>
        /// <returns> an instance of the webelement</returns>
        public static IWebElement WaitTillElementExist(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

            if (elementLocatorType == ElementLocator.Xpath)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            }
            else if (elementLocatorType == ElementLocator.PartialLinkText)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.PartialLinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.Name)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.Name(locator)));
            }
            else if (elementLocatorType == ElementLocator.LinkText)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.LinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.ID)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.Id(locator)));
            }
            else if (elementLocatorType == ElementLocator.CssSelector)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(locator)));
            }
            else if (elementLocatorType == ElementLocator.TagName)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.TagName(locator)));
            }
            else if (elementLocatorType == ElementLocator.ClassName)
            {
                _webElement = wait.Until(ExpectedConditions.ElementExists(By.ClassName(locator)));
            }

            return _webElement;
        }

        /// <summary>
        /// Create a instance of Selenium webElement
        /// </summary>
        /// <param name="locator">Locator path</param>
        /// <param name="elementLocatorType"> Locator Type i.e. Xpath,Id,etc.</param>
        /// <param name="TimeOutForFindingElement"> Number of seconds an element should wait for a webelement to display or exists </param>
        /// <returns> an instance of the webelement</returns>
        public static IWebElement WaitTillElementDisplayed(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

            if (elementLocatorType == ElementLocator.Xpath)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            else if (elementLocatorType == ElementLocator.PartialLinkText)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.Name)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator)));
            }
            else if (elementLocatorType == ElementLocator.LinkText)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.ID)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            }
            else if (elementLocatorType == ElementLocator.CssSelector)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
            }
            else if (elementLocatorType == ElementLocator.TagName)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator)));
            }
            else if (elementLocatorType == ElementLocator.ClassName)
            {
                _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator)));
            }

            return _webElement;
        }

        /// <summary>
        /// Create a instance of Selenium webElement when element staleness is gone 
        /// </summary>
        /// <param name="locator">Locator path</param>
        /// <param name="elementLocatorType"> Locator Type i.e. Xpath,Id,etc.</param>
        /// <param name="TimeOutForFindingElement"> Number of seconds an element should wait for a webelement to display or exists </param>
        public static void WaitTillElementStalenessOf(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

            if (elementLocatorType == ElementLocator.Xpath)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.XPath(locator))));
            }
            else if (elementLocatorType == ElementLocator.PartialLinkText)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.PartialLinkText(locator))));
            }
            else if (elementLocatorType == ElementLocator.Name)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.Name(locator))));
            }
            else if (elementLocatorType == ElementLocator.LinkText)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.LinkText(locator))));
            }
            else if (elementLocatorType == ElementLocator.ID)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.Id(locator))));
            }
            else if (elementLocatorType == ElementLocator.CssSelector)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.CssSelector(locator))));
            }
            else if (elementLocatorType == ElementLocator.TagName)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.TagName(locator))));
            }
            else if (elementLocatorType == ElementLocator.ClassName)
            {
                wait.Until(ExpectedConditions.StalenessOf(Driver.Browser.FindElement(By.ClassName(locator))));
            }
        }
    }

    /// <summary>
    ///  Helper Componnents 
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Autosuggest Helper components
        /// </summary>
        private readonly AutoSuggest AutoSuggestHelper = new AutoSuggest();

        /// <summary>
        /// Mouse Action Helper components  
        /// </summary>
        private readonly MouseAction MouseActionHelper = new MouseAction();

        /// <summary>
        /// KeyBoard Action Helper components 
        /// </summary>
        private readonly KeyBoardAction KeyBoardActionHelper = new KeyBoardAction();

        /// <summary>
        /// Browser Helper Components 
        /// </summary>
        private readonly Browser BrowserHelper = new Browser();

        /// <summary>
        /// All Button Helper Component
        /// </summary>
        private readonly Button ButtonHelper = new Button();

        /// <summary>
        /// CheckBox Helper Components
        /// </summary>
        private readonly CheckBox CheckBoxHelper = new CheckBox();

        /// <summary>
        /// ComboBox Helper Components
        /// </summary>
        private readonly ComboBox ComboBoxHelper = new ComboBox();

        /// <summary>
        /// JavaScript Helper Components 
        /// </summary>
        private readonly JavascriptHelp JavaScriptHelper = new JavascriptHelp();

        /// <summary>
        /// Label Helper Components
        /// </summary>
        private readonly  Label LabelHelper = new Label();

        /// <summary>
        /// Link Helper Components 
        /// </summary>
        private readonly Link LinkHelper = new Link();

        /// <summary>
        /// Radio Button Helper Components
        /// </summary>
        private readonly RadioButton RadioButtonHelper = new RadioButton();

        /// <summary>
        /// TextBox Helper Components
        /// </summary>
        private readonly Text TextBoxHelper = new Text();
    }
}
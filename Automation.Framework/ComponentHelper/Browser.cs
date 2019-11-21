using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Automation.Framework.ComponentHelper
{
    public class Browser : IBrowserHelper
    {
        /// <summary>
        /// Retrieves browser title 
        /// </summary>
        /// <returns>Browser Title</returns>
        public string GetBrowserTitle()
        {
            return Driver.Browser.Title;
        }

        /// <summary>
        /// Retrieves browser's current URL
        /// </summary>
        /// <returns>URL</returns>
        public string GetBrowserUrl()
        {
            return Driver.Browser.Url;
        }


        /// <summary>
        /// Maximize the browser
        /// </summary>
        public void BrowserMaximise()
        {
            Driver.Browser.Manage().Window.Maximize();
        }

        /// <summary>
        /// Minimize browser
        /// </summary>
        public void BrowserMinimise()
        {
            Driver.Browser.Manage().Window.Minimize();
        }

        /// <summary>
        /// Refreshes browser
        /// </summary>
        public void BrowserRefresh()
        {
            Driver.Browser.Navigate().Refresh();
        }

        /// <summary>
        /// Moves backward in the browser
        /// </summary>
        public void MoveBackward()
        {
            Driver.Browser.Navigate().Back();
        }

        /// <summary>
        /// Moves forward in the browser
        /// </summary>
        public void MoveForward()
        {
            Driver.Browser.Navigate().Forward();
        }

        /// <summary>
        /// Navigate to specified URL
        /// </summary>
        /// <param name="url"> URL </param>
        public void Navigate(string url)
        {
            Driver.Browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Switches to specified window
        /// </summary>
        /// <param name="index">Window index</param>
        public void SwitchToWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = Driver.Browser.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }

            Driver.Browser.SwitchTo().Window(windows[index]);
        }

        /// <summary>
        /// Switches to the parent window 
        /// </summary>
        public void SwitchToParent()
        {
            var windowids = Driver.Browser.WindowHandles;

            for (int i = windowids.Count - 1; i > 0; i--)
            {
                Driver.Browser.SwitchTo().Window(windowids[i]);
                Driver.Browser.Close();
            }
            Driver.Browser.SwitchTo().Window(windowids[0]);
        }

        /// <summary>
        /// Switches webdriver to specified iframe component
        /// </summary>
        /// <param name="frameElement">IFrame WebElement</param>
        public void SwitchToFrame(IWebElement frameElement)
        {
            Driver.Browser.SwitchTo().Frame(frameElement);
        }
    }
}
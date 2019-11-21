using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Automation.Framework.ComponentHelper
{
    public class Browser : IBrowserHelper
    {
        public string GetBrowserTitle()
        {
            return Driver.Browser.Title;
        }

        public string GetBrowserUrl()
        {
            return Driver.Browser.Url;
        }

        public void BrowserMaximise()
        {
            Driver.Browser.Manage().Window.Maximize();
        }

        public void BrowserMinimise()
        {
            Driver.Browser.Manage().Window.Minimize();
        }

        public void BrowserRefresh()
        {
            Driver.Browser.Navigate().Refresh();
        }

        public void MoveBackward()
        {
            Driver.Browser.Navigate().Back();
        }

        public void MoveForward()
        {
            Driver.Browser.Navigate().Forward();
        }

        public void Navigate(string url)
        {
            Driver.Browser.Navigate().GoToUrl(url);
        }

        public void SwitchToWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = Driver.Browser.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }

            Driver.Browser.SwitchTo().Window(windows[index]);
        }

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

        public void SwitchToFrame(IWebElement frameElement)
        {
            Driver.Browser.SwitchTo().Frame(frameElement);
        }
    }
}
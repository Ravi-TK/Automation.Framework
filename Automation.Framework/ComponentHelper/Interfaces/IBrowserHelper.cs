using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IBrowserHelper
    {
        void MoveForward();
        void MoveBackward();
        void BrowserMaximise();
        void BrowserMinimise();
        void BrowserRefresh();
        void Navigate(string url);
        string GetBrowserTitle();
        string GetBrowserUrl();
        void SwitchToWindow(int index = 0);
        void SwitchToParent();
        void SwitchToFrame(IWebElement frameElement);
    }
}

﻿using OpenQA.Selenium;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    internal interface IMouseActionHelper
    {
        void DragNDrop(IWebElement src, IWebElement trg);

        void ClickNHoldNDrop(IWebElement element, IWebElement trg, int x = 0, int y = 30);

        void DoubleClickOnElement(IWebElement element);
    }
}
using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Framework.ComponentHelper
{
    public class MouseAction : IMouseActionHelper
    {
        public void ClickNHoldNDrop(IWebElement Element, IWebElement trg, int x = 0, int y = 30)
        {
            Actions act = new Actions(Driver.Browser);

            act.ClickAndHold(Element)
                .MoveToElement(trg, x, y)
                .Release()
                .Build()
                .Perform();
        }

        public void DoubleClickOnElement(IWebElement element)
        {
            Actions act = new Actions(Driver.Browser);

            act.DoubleClick(element)
                .Build()
                .Perform();
        }

        public void DragNDrop(IWebElement src, IWebElement trg)
        {
            Actions act = new Actions(Driver.Browser);

            act.DragAndDrop(src, trg)
                .Build()
                .Perform();
        }
    }
}
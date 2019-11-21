using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Framework.ComponentHelper
{
    public class MouseAction : IMouseActionHelper
    {
        /// <summary>
        /// Clicks on a element, hold and drop it on the specified location
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="trg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ClickNHoldNDrop(IWebElement Element, IWebElement trg, int x = 0, int y = 30)
        {
            Actions act = new Actions(Driver.Browser);

            act.ClickAndHold(Element)
                .MoveToElement(trg, x, y)
                .Release()
                .Build()
                .Perform();
        }

        /// <summary>
        /// Double clicks on the specified element 
        /// </summary>
        /// <param name="element">Item to be double clicked, its WebElement </param>
        public void DoubleClickOnElement(IWebElement element)
        {
            Actions act = new Actions(Driver.Browser);

            act.DoubleClick(element)
                .Build()
                .Perform();
        }

        /// <summary>
        /// Drag an element and drop it in the spcified element
        /// </summary>
        /// <param name="src">Source item WebElement</param>
        /// <param name="trg">Target item WebElement</param>
        public void DragNDrop(IWebElement src, IWebElement trg)
        {
            Actions act = new Actions(Driver.Browser);

            act.DragAndDrop(src, trg)
                .Build()
                .Perform();
        }
    }
}
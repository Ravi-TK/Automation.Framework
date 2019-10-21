using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper
{
    public class KeyBoardAction : IKeyboardAction
    {
        public void DoubleCommandKeyAction(string cmdKey1, string cmdKey2, string character)
        {
            Actions act = new Actions(Driver.Browser);

            act.KeyDown(cmdKey1)
                .KeyDown(cmdKey2)
                .SendKeys(character)
                .KeyUp(cmdKey2)
                .KeyUp(cmdKey1)
                .Build()
                .Perform();
        }

        public void SingleCommandKeyAction(string cmdKey, string character)
        {
            Actions act = new Actions(Driver.Browser);

            act.KeyDown(cmdKey)
                .SendKeys(character)
                .KeyUp(cmdKey)
                .Build()
                .Perform();
        }

        public void SingleCommandKeyAction(string cmdKey, string character1, string character2)
        {
            Actions act = new Actions(Driver.Browser);

            act.KeyDown(cmdKey)
                .SendKeys(character1)
                .SendKeys(character2)
                .KeyUp(cmdKey)
                .Build()
                .Perform();
        }
    }
}

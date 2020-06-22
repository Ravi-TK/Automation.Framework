using Automation.Framework.ComponentHelper.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium.Interactions;

namespace Automation.Framework.ComponentHelper
{
    public class KeyBoardAction : IKeyboardAction
    {
        /// <summary>
        /// Automate the key pressing combination e.g. Ctrl+Shift+T
        /// </summary>
        /// <param name="cmdKey1">Command Key 1</param>
        /// <param name="cmdKey2">COmmand Key 2</param>
        /// <param name="character">Char</param>
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

        /// <summary>
        /// Automate command and key pressing event
        /// </summary>
        /// <param name="cmdKey">Command key </param>
        /// <param name="character">Char</param>
        /// <remark> Ctrl+T does not work for chrome browser. </remark>
        public void SingleCommandKeyAction(string cmdKey, string character)
        {
            Actions act = new Actions(Driver.Browser);

            act.KeyDown(cmdKey)
                .SendKeys(character)
                .KeyUp(cmdKey)
                .Build()
                .Perform();
        }

        /// <summary>
        /// Automate command and multiple key pressing action 
        /// </summary>
        /// <param name="cmdKey">Command key</param>
        /// <param name="character1">Key 1</param>
        /// <param name="character2">Keys 2</param>
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
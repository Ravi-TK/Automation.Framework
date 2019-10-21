using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Unity;
using Unity.Lifetime;

namespace Automation.Framework.Test
{
    [TestClass]
    public class Hooks
    {

        [AssemblyInitialize]
        public static void BeforeTestRun(TestContext context)
        {
            Driver.StartBrowser(BrowserTypes.Chrome);
            UnityContainerFactory.GetContainer().RegisterType<W3schoolPage>(new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
        }

        [TestInitialize]
        public void BeforeTest()
        {
            
        }

        [TestCleanup]
        public void AfetrTest()
        {
            // Runs after each test. (Optional)
        }

        [AssemblyCleanup]
        public static void AfterTestRun()
        {
            Driver.StopBrowser();
        }

    }
}

using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
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
            Driver.StartBrowser(BrowserTypes.ChromeHeadless,30, GetChromeOptions());
            UnityContainerFactory.GetContainer().RegisterType<W3schoolPage>(new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            //commments
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
            options.EnableNativeEvents = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            return options;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("window-size=1920,1080");
            return chromeOptions;
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
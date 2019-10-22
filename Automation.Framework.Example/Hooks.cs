using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Example.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;

namespace Automation.Framework.Example
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //registering page classes. 
            UnityContainerFactory.GetContainer().RegisterType<LandingPage>(new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer().RegisterType<SignInPage>(new ContainerControlledLifetimeManager());

            //choosing the browser to run 
            Driver.StartBrowser(BrowserTypes.Chrome);

            //Registering BrowserDriver
            UnityContainerFactory.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Driver.StopBrowser();
        }

    }
}

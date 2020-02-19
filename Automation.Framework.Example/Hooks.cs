using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Example.BackEnd;
using Automation.Framework.Example.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;

namespace Automation.Framework.Example
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext scenarioContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentKlovReporter klov;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        //clears screen shot folder before the test run 
        private static void clearScreenShots()
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, "ScreenShots");
            System.IO.DirectoryInfo ScreenShotdir = new System.IO.DirectoryInfo(pathString);
            if (ScreenShotdir.Exists) ScreenShotdir.Delete(true);
        }

        private static void reportInitalise()
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, @"Reports\Reports " + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss"));
            System.IO.DirectoryInfo ScreenShotdir = new System.IO.DirectoryInfo(pathString);

            if (!ScreenShotdir.Exists)
                System.IO.Directory.CreateDirectory(pathString);

            var htmlReporter = new ExtentHtmlReporter(pathString + "\\TestReport " + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            #region Klov Reporter sample
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            // klov = new ExtentKlovReporter();

            //  klov.InitMongoDbConnection("localhost", 27017);
            //  klov.ProjectName = "Income And Expenses Sanisbury";

            //klov.ReportName = "Ravi Kota" + DateTime.Now.ToString();
            // klov.InitKlovServerConnection("http://localhost:5689");
            #endregion

            extent.AttachReporter(htmlReporter);
        }

        public static void SetUp()
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("AppConfig.json")
                                .Build();

            string environment = config["Environment"];

            //clearing screen shots 
            clearScreenShots();

            //Setting test environment
            if (environment.Equals("Dev"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.Dev);
            else if (environment.Equals("SysTest"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.SysTest);
            else if (environment.Equals("UAT"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.UAT);
            else if (environment.Equals("Staging"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.Staging);

            //Set Base URL for the APP
            BaseUrl.SetBaseUrl(EnvirnomentConfig.TestEnvirnoment);

            //Set DB Connection strings
            DBConnectionStrings.SetDBConnectionString(EnvirnomentConfig.TestEnvirnoment);

            //Initialize Log File
            Driver.CreateLog("Logs ");

            //Initialize Reports
            reportInitalise();

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SetUp();

            //Registering pages
            UnityContainerFactory.GetContainer().RegisterType<LandingPage>(new ContainerControlledLifetimeManager());
            UnityContainerFactory.GetContainer().RegisterType<SignInPage>(new ContainerControlledLifetimeManager());

            Log.Information("");
            Log.Information("\nNew Test Cycle :");
        }

        public static void setUpBrowser()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("AppConfig.json")
                    .Build();

            string browserName = config["Browser"];

            if (browserName.Equals("Chrome"))
                Driver.StartBrowser(BrowserTypes.Chrome, 30, GetChromeOptions());
            else if (browserName.Equals("ChromeHeadless"))
                Driver.StartBrowser(BrowserTypes.ChromeHeadless, 30, GetChromeOptions());
            else if (browserName.Equals("Edge"))
                Driver.StartBrowser(BrowserTypes.Edge, 30);
            else if (browserName.Equals("Firefox"))
                Driver.StartBrowser(BrowserTypes.Firefox, 30);
            else if (browserName.Equals("FirefoxHeadless"))
                Driver.StartBrowser(BrowserTypes.FirefoxHeadless, 30);
            else if (browserName.Equals("InternetExplorer"))
                Driver.StartBrowser(BrowserTypes.InternetExplorer, 30, GetIEOptions());
            else if (browserName.Equals("Opera"))
                Driver.StartBrowser(BrowserTypes.Opera, 30);
            else if (browserName.Equals("Safari"))
                Driver.StartBrowser(BrowserTypes.Safari, 30);

            //Registering BrowserDriver
            UnityContainerFactory.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            setUpBrowser();

            Log.Information("[Feature] : {0}", FeatureContext.Current.FeatureInfo.Title);
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        private static InternetExplorerOptions GetIEOptions()
        {
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

        [BeforeScenario]
        public void BeforeScenario()
        {
            Log.Information("[Scenario Start] : {0}", scenarioContext.ScenarioInfo.Title);
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Log.Information("[Step] : {0}", scenarioContext.StepContext.StepInfo.Text);
        }

        [AfterStep]
        public void AfterStep()
        {
            if (scenarioContext.TestError != null)
            {
                Log.Error(scenarioContext.TestError.ToString());
                Log.Debug(scenarioContext.TestError.StackTrace);
                Log.Error(scenarioContext.TestError.Source);
            }

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(scenarioContext, null);

            if (scenarioContext.TestError == null)
            {
                if (!scenarioContext.ScenarioInfo.Tags.ToString().Contains("manual"))
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                }
            }
            else if (scenarioContext.TestError != null)
            {
                Thread.Sleep(2000);

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace + "\n\n\t\tScreenShot \n\n",
                      MediaEntityBuilder.CreateScreenCaptureFromPath(Driver.TakeScreenShot(scenarioContext.StepContext.StepInfo.Text.Substring(0, 10))).Build());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace + "\n\n\t\tScreenShot \n\n",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Driver.TakeScreenShot(scenarioContext.StepContext.StepInfo.Text.Substring(0, 10))).Build());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace + "\n\n\t\tScreenShot \n\n",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Driver.TakeScreenShot(scenarioContext.StepContext.StepInfo.Text.Substring(0, 10))).Build());
                }
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Log.Information("[scenario completed]");
            Log.Information("------------------------------------------------------------");

        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Driver.StopBrowser();

            Log.Information("[Feature completed] ");
            Log.Information("==============================================================");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.CloseAndFlush();
            extent.Flush();
        }

    }
}
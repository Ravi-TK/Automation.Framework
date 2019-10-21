using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.IO;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Automation.Framework.Core
{
    public static class Driver
    {
        private static WebDriverWait _browserWait;
        private static IWebDriver _browser;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _browser;
            }
            set
            {
                _browser = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Firefox, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    Browser = new FirefoxDriver();
                    break;
                case BrowserTypes.InternetExplorer:
                    Browser = new InternetExplorerDriver(GetIEOptions());
                    break;
                case BrowserTypes.Chrome:
                    Browser = new ChromeDriver();
                    break;
                case BrowserTypes.ChromeHeadless:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("disable-gpu");
                    Browser = new ChromeDriver(chromeOptions);
                    break;
                default:
                    Browser = new ChromeDriver();
                    break;
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        //private static FirefoxOptions GetFireFoxoptions()
        //{

        //}

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

        public static string TakeScreenShot(string filename)
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, "ScreenShots");
            System.IO.DirectoryInfo ScreenShotdir = new System.IO.DirectoryInfo(pathString);

            if (!ScreenShotdir.Exists)
                System.IO.Directory.CreateDirectory(pathString);

            var screen = Driver.Browser.TakeScreenshot();
            filename = filename + " " + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            filename = Path.Combine(pathString, filename);
            screen.SaveAsFile(filename);

            return filename;
        }

        public static void CreateLog(string fileName = "Log .txt ")
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, "Logs");
            System.IO.Directory.CreateDirectory(pathString);

            fileName = Path.Combine(pathString, fileName);

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.File(fileName, rollingInterval: RollingInterval.Day,
                 rollOnFileSizeLimit: true)
             .CreateLogger();
        }
        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
    }
}


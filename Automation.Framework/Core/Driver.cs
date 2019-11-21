using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.IO;

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

        /// <summary>
        /// Creates an istance of selected browser
        /// </summary>
        /// <param name="browserType"> Type of Browser user wants to create </param>
        /// <param name="defaultTimeOut">Time until the webdriver should try to create an instance of webdriver</param>
        /// <param name="browserOptions"> Options for the browser </param>
        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Firefox, int defaultTimeOut = 30, object browserOptions = null)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    if (browserOptions != null)
                        Browser = new FirefoxDriver((FirefoxOptions)browserOptions);
                    else
                        Browser = new FirefoxDriver();
                    break;

                case BrowserTypes.FirefoxHeadless:
                    ((FirefoxOptions)browserOptions).AddArguments("--headless");
                    Browser = new FirefoxDriver((FirefoxOptions)browserOptions);
                    break;

                case BrowserTypes.InternetExplorer:
                    if (browserOptions != null)
                        Browser = new InternetExplorerDriver((InternetExplorerOptions)browserOptions);
                    else
                        Browser = new InternetExplorerDriver();
                    break;

                case BrowserTypes.Chrome:
                    if (browserOptions != null)
                        Browser = new ChromeDriver((ChromeOptions)browserOptions);
                    else
                        Browser = new ChromeDriver();
                    break;

                case BrowserTypes.ChromeHeadless:
                    if (browserOptions != null)
                    {
                        ((ChromeOptions)browserOptions).AddArgument("--headless");
                        ((ChromeOptions)browserOptions).AddArgument("disable-gpu");
                    }
                    else
                    {
                        browserOptions = new ChromeOptions();
                        ((ChromeOptions)browserOptions).AddArgument("--headless");
                        ((ChromeOptions)browserOptions).AddArgument("disable-gpu");
                    }

                    Browser = new ChromeDriver((ChromeOptions)browserOptions);
                    break;

                case BrowserTypes.Edge:
                    if (browserOptions != null)
                        Browser = new EdgeDriver((EdgeOptions)browserOptions);
                    else
                        Browser = new EdgeDriver();
                    break;

                case BrowserTypes.Safari:
                    if (browserOptions != null)
                        Browser = new SafariDriver((SafariOptions)browserOptions);
                    else
                        Browser = new SafariDriver();
                    break;

                case BrowserTypes.Opera:
                    if (browserOptions != null)
                        Browser = new OperaDriver((OperaOptions)browserOptions);
                    else
                        Browser = new OperaDriver();
                    break;
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
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
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using SogetiTestFramework.Helper;

namespace SogetiTestFramework.Utility
{

    /// <summary>
    /// The BaseWebDriver class will implement the functionality related to the Selenuim  
    /// WebDriver object. BaseWebDriver is exposed to the test Page classes through the 
    /// BasePage Class.
    /// </summary>
    /// <author>Chris Macgowan</author>
    /// <date>31 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    /// <remarks>
    /// The BaseWebDriver object will only support ChromeDriver at this time. We will 
    /// implement Firefox, IE and other drivers when we implement the PropertiesManager 
    /// and TestConfiguration supporting classes. 
    /// </remarks>
    public class BaseWebDriver 
    {
        private static readonly Log logger = new Log(typeof(BaseWebDriver));

        protected TestConfiguration testConfiguration = new TestConfiguration();

        protected static IWebDriver driver;

        /// <summary>
        /// Default constructor. We will create the driver object. 
        /// </summary>
        public BaseWebDriver()
        {
            Init();
        }

        /// <summary>
        /// Return the WebDriver driver object. 
        /// </summary>
        /// <returns> Return the WebDriver driver object.</returns>
        public IWebDriver GetDriver()
        {
            return driver;
        }

        /// <summary>
        /// Creates a new instance of WebDriver, setsup initial settings for browser.
        /// </summary>
        private void Init()
        {
            switch(testConfiguration.GetBrowserType().ToLower())
            {
                case Constants.BrowserTypeFirefox:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(testConfiguration.GetBrowserTimeoutSeconds()));
                    break;

                case Constants.BrowserTypeChrome:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(testConfiguration.GetBrowserTimeoutSeconds()));
                    break;

                case Constants.BrowserTypeIE:
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(testConfiguration.GetBrowserTimeoutSeconds()));
                    break;

                case Constants.BrowserTypeEdge:
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(testConfiguration.GetBrowserTimeoutSeconds()));
                    break;

                case Constants.BrowserTypeSafari:
                    driver = new SafariDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(testConfiguration.GetBrowserTimeoutSeconds()));
                    break;

                default:

                    // The browser type from testConfiguration did not match any valid 
                    // options - we will throw the exception
                    
                    string errorMessage = string.Format("Browser type is not valid. The browserType is " +
                        "set in the configuration file or on the command line. browserType: {0}",
                                    testConfiguration.GetBrowserType());

                    logger.Error(errorMessage);

                    throw new System.Exception(errorMessage); 
            }
        }

        /// <summary>
        /// Quit WebDriver, closing all assosiated windows. 
        /// </summary>
        public void Teardown()
        {
            driver.Quit();
        }
    }
}

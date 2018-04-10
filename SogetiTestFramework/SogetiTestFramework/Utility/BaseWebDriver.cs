using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
        
        // The following objects are used to support the BaseWebDriver object
        // The commented lines are placeholders for future development

        protected static IWebDriver driver;

        // protected PropertiesManager properties;

        // protected TestConfiguration config;

        // private final static Log logger = new Log(AbstractPage.class);


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
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
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

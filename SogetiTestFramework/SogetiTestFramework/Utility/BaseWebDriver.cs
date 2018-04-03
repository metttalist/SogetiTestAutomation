using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
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
    /// The BaseWebDriver object will only support FirefoxDriver at this time. We will 
    /// implement Chrome, IE and other drivers when we implement the PropertiesManager 
    /// and TestConfiguration supporting classes. 
    /// </remarks>
    class BaseWebDriver
    {
        
        // The following objects are used to support the BaseWebDriver object
        // The commented lines are placeholders for future development

        protected static FirefoxDriver driver;

        // protected PropertiesManager properties;

        // protected TestConfiguration config;
        
        // private final static Log logger = new Log(AbstractPage.class);


        /// <summary>
        /// Default constructor. We will create the driver object. 
        /// </summary>
        public void BasePage()
        {
            driver = new FirefoxDriver();
        }

        /// <summary>
        /// Return the FirefoxDriver driver object. 
        /// </summary>
        /// <returns> Return the FirefoxDriver driver object.</returns>
        public FirefoxDriver getDriver()
        {
            return driver;
        }
    }
}

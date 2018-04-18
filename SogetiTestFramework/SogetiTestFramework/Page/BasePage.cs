using OpenQA.Selenium;
using SogetiTestFramework.Helper;
using SogetiTestFramework.Utility;
using System.Collections.ObjectModel;

namespace SogetiTestFramework.Page
{

    /// <summary>
    /// The BasePage class will implement the functionality related to the page 
    /// object. Page classes that support specific webpages will inherit from this class.
    /// </summary>
    /// <author>Chris Macgowan, Igor Khorev</author>
    /// <date>30 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class BasePage
    {
        // The following objects are used to support the BasePage object
        // The commented lines are placeholders for future development
        
        protected TestConfiguration testConfiguration = new TestConfiguration();
        
        protected BaseWebDriver webDriver = new BaseWebDriver();

        protected IWebElement element;

        protected ReadOnlyCollection<IWebElement> elements;

        private static readonly Log logger = new Log(typeof(BasePage));

        /// <summary>
        /// Navigates to a specified Url.
        /// </summary>
        /// <param name="Url"></param>
        public void NavigateToUrl(string Url)
        {
            webDriver.GetDriver().Navigate().GoToUrl(Url);
            logger.Debug("Navigated to: '{0}'", Url);
        }

        /// <summary>
        /// Quits the WebDriver, closing all openned windows.
        /// </summary>
        public void Teardown()
        {
            webDriver.GetDriver().Quit();
        }
    }
}

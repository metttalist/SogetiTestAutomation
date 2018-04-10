using OpenQA.Selenium;
using SogetiTestFramework.Utility;
using System.Collections.ObjectModel;

namespace SampleTestProject.Page
{
    /// <summary>
    /// The GoogleSearchHomePage class will support the Google Search Home page. This class will provide access
    /// to web elements on the page and helper methods. 
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>4 Apr 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class GoogleSearchHomePage : BaseSampleTestProjectPage
    {
        /////////////////////////////////////////////////////////
        //SELECTORS
        ////////////////////////////////////////////////////////

        /// <summary>
        /// Returns Search Field.
        /// </summary>
        /// <returns>IWebElement Search Field</returns>
        public IWebElement GetSearchField()
        {
            element = webDriver.GetDriver().FindElement(By.Id("lst-ib"));
            return element;
        }
        /// <summary>
        /// Returns Search Button.
        /// </summary>
        /// <returns>IWebElement Search Button.</returns>
        public IWebElement GetGoogleSearchButton()
        {
            element = webDriver.GetDriver().FindElement(By.XPath("//input[@type='submit'][@name='btnK']"));
            return element;
        }

        /// <summary>
        /// Returns a list of search results links.
        /// </summary>
        /// <param name="ItemToSearch"></param>
        /// <returns></returns>
        public ReadOnlyCollection<IWebElement> GetSearchResultsLinks(string ItemToSearch)
        {
            elements = webDriver.GetDriver().FindElements(By.XPath("//a[contains(text(), '" + ItemToSearch + "')]"));
            return elements;
        }

        /////////////////////////////////////////////////////////
        //HELPER METHODS
        /////////////////////////////////////////////////////////
    }
}

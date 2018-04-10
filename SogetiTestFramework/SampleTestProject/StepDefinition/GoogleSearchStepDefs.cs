using TechTalk.SpecFlow;
using SampleTestProject.Page;
using OpenQA.Selenium;
using SogetiTestFramework.Utility;
using System.Collections.ObjectModel;

namespace SampleTestProject.StepDefinition
{
    /// <summary>
    /// The GoogleSearchStepDefs class will implement the functionality within "Google Search" page
    /// that is described in the SpecFlow feature file.
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>4 Apr 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    [Binding]
    public class GoogleSearchStepDefs : BaseSampleTestProjectStepDefinition
    {
        private GoogleSearchHomePage googleHomePage;

        /// <summary>
        /// Initial setup for all step definitions within Google Search Home page.
        /// </summary>
        [BeforeScenario]
        public void Setup()
        {
            googleHomePage = new GoogleSearchHomePage();
        }
        /// <summary>
        /// Navigates to Google Search Home page
        /// </summary>
        [Given(@"I navigated to Google home page")]
        public void NavigateToGoogleHomePage()
        {
            googleHomePage.NavigateToUrl(App1BaseUrl);
            DelayForNexAction(ShortIntervalInMilliseconds);
        }
        /// <summary>
        /// Types the item to search into serach bar.
        /// </summary>
        /// <param name="ItemToSearch"></param>
        [When(@"I enter '(.*)' into search bar")]
        public void WhenIEnterIntoSearchBar(string ItemToSearch)
        {
            googleHomePage.GetSearchField().Clear();
            googleHomePage.GetSearchField().SendKeys(ItemToSearch);
        }
        /// <summary>
        /// Presses "Enter" key on a keyboard.
        /// </summary>
        [When(@"I press Enter key on my keyboard")]
        public void PressEnterKeyWhileSearchFieldInFocus()
        {
            googleHomePage.GetSearchField().SendKeys(Keys.Enter);
        }
        /// <summary>
        /// Validates search results.
        /// </summary>
        [Then(@"search results list of '(.*)' is displayed")]
        public void ThenSearchResultsListOfIsDisplayed(string searchedltItem)
        {
            ReadOnlyCollection<IWebElement> actualSearchResultItems = googleHomePage.
                GetSearchResultsLinks(searchedltItem);

            foreach (var item in actualSearchResultItems)
            {
                softAsseert.AssertThatContainsString(item.Text.ToLower(), searchedltItem.ToLower());
            }
            softAsseert.ProcessAsserts();
        }

        /// <summary>
        /// Cleans up all the data after test scenarion is done.
        /// </summary>
        [AfterScenario]
        public void Teardown()
        {
            googleHomePage.Teardown();
        }
    }
}

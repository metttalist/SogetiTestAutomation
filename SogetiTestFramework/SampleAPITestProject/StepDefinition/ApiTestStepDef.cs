using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SogetiTestFramework.Helper;
using SogetiTestFramework.Rest;
using TechTalk.SpecFlow;

namespace SampleAPITestProject.StepDefinition
{
    [Binding]
    public sealed class ApiTestStepDef : BaseSampleTestAPIStepDefinition
    {
        private static readonly Log logger = new Log(typeof(ApiTestStepDef));

        BaseRestClient baseRestClient = new BaseRestClient(); 

        /// <summary>
        /// Initial setup for all step definitions within Google Search Home page.
        /// </summary>
        [BeforeScenario]
        public void Setup()
        {
            logger.Debug("Inside ApiTestStepDef::Setup()");
        }

        [Given(@"I am an authorized user")]
        public void GivenIAmAnAuthorizedUser()
        {
            // ScenarioContext.Current.Pending();
            logger.Debug("Inside ApiTestStepDef::GivenIAmAnAuthorizedUser()");
        }


        [When(@"I submit the Get request to the test URL")]
        public void WhenISubmitTheGetRequestToTheTestURL()
        {
            logger.Debug("Inside ApiTestStepDef::WhenISubmitTheGetRequestToTheTestURL()");

            logger.Debug(string.Format("Calling Test API", testConfiguration.GetApplicationURL()));

            string response = baseRestClient.Get(testConfiguration.GetApplicationURL(),
                                    testConfiguration.GetUserName(),
                                    testConfiguration.GetUserPassword());
        }


        [Then(@"the response has the expected HTTP Code")]
        public void ThenTheResponseHasTheExpectedHTTPCode()
        {
            logger.Debug("Inside ApiTestStepDef::ThenTheResponseHasTheExpectedHTTPCode()");
        }


        /// <summary>
        /// Cleans up all the data after test scenarion is done.
        /// </summary>
        [AfterScenario]
        public void Teardown()
        {
            logger.Debug("Inside ApiTestStepDef::Teardown()");
        }


    }
}

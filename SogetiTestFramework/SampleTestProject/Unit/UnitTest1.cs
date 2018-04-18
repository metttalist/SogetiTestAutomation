using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SogetiTestFramework.Helper;
using SogetiTestFramework.Rest;

namespace SampleTestProject.Unit
{




    /// <summary>
    ///   This class can be used to test the GET api base method.
    /// </summary>
    /// <author>Jeff Bertram</author>
    /// <date>April 10, 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    [TestClass]
    public class UnitTest1 : BaseRestClient
    {

        private static readonly Log logger = new Log(typeof(UnitTest1));

        [TestMethod]
        public void TestMethod1()
        {
            logger.Debug(string.Format("Calling Test API", testConfiguration.GetApplicationURL()));

            IRestResponse response = Get(testConfiguration.GetApplicationURL(),
                                    testConfiguration.GetUserName(),
                                    testConfiguration.GetUserPassword(),
                                    "header");

            // System.Net.HttpStatusCode.OK
            // Force the failure
            softAsseert.AssertThatContainsString(response.StatusCode.ToString(), "OK");
            softAsseert.AssertThatContainsString(response.StatusDescription.ToString(), "OK");
            softAsseert.ProcessAsserts();
        }
    }
}

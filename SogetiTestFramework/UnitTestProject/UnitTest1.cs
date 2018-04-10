using Microsoft.VisualStudio.TestTools.UnitTesting;
using SogetiTestFramework.Rest;

namespace SampleAPITestProject
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

        [TestMethod]
        public void TestGetMethod()
        {                
            string restStatus = GetMethod("http://services.groupkt.com/country/get/all", "", "");
        }
    }
}

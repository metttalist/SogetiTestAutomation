using SogetiTestFramework.Utility;
using System;

namespace SogetiTestFramework.StepDefinition
{
    /// <summary>
    /// The BaseStepDefinition class will implement all common functionality related to the Step Definitions. 
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>28 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class BaseStepDefinition
    {

        protected TestConfiguration testConfiguration = new TestConfiguration();

        protected SoftAssert softAsseert = new SoftAssert();
        protected Globals globals = new Globals();

        public static readonly int ShortIntervalInMilliseconds = 1000;
        public static readonly int MediumIntervalInMilliseconds = 3000;
        public static readonly int LongIntervalInMilliseconds = 5000;

        /// <summary>
        /// Pause code execution for scpesified time period.
        /// </summary>
        /// <param name="TimeoutInMilliSeconds"></param>
        public void DelayForNexAction(int TimeoutInMilliSeconds)
        {
            try
            {
                System.Threading.Thread.Sleep(TimeoutInMilliSeconds);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}

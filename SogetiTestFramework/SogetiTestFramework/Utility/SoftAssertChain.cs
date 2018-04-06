using System;
using System.Collections.Generic;

namespace SogetiTestFramework.Utility
{
    /// <summary>
    /// This class is used to collect all failurs that occured during test execution using soft asserttions.
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>28 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class SoftAssertChain
    {
        private BaseList<Exception> failures;

        public SoftAssertChain()
        {
            failures = new BaseList<Exception>();
        }

        /// <summary>
        /// Adds a failure to the list.
        /// </summary>
        /// <param name="failure"></param>
        public void AddFailure(Exception failure)
        {
            this.failures.Add(failure);
        }

        /// <summary>
        /// Resets the list of failures.
        /// </summary>
        public void Reset()
        {
            this.failures.Clear();
        }

        /// <summary>
        /// Returns the list of failures.
        /// </summary>
        /// <returns></returns>
        public BaseList<Exception> GetFailures()
        {
            return this.failures;
        }
    }
}

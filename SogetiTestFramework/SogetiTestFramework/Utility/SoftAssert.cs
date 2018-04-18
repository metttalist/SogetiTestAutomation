using System;
using NUnit.Framework;
using SogetiTestFramework.Helper;

namespace SogetiTestFramework.Utility
{
    /// <summary>
    /// This class provides soft assertion functionality for the framework. Failed assertions only recorded
    /// not trown. Once all assertions have been performed "ProcessAsserts()" methods needs to be used to throw all
    /// recorded failures as well as to reset its state for the next executins.
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>28 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class SoftAssert
    {
        private static readonly Log logger = new Log(typeof(SoftAssert));

        private SoftAssertChain softAssertChain = new SoftAssertChain();

        /// <summary>
        /// Assert that the objects are equal.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public void AssertThatEquals(Object actual, Object expected)
        {
            try
            {
                Assert.AreEqual(actual, expected);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }
        /// <summary>
        ///  Assert that the objects are equal.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="reason"></param>
        public void AssertThatEquals(Object actual, Object expected, string reason)
        {
            try
            {
                Assert.AreEqual(actual, expected, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        ///  Assert that the objects are not equal.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public void AssertThatNotEquals(Object actual, Object expected)
        {
            try
            {
                Assert.AreNotEqual(actual, expected);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        ///  Assert that the objects are not equal.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="reason"></param>
        public void AssertThatNotEquals(Object actual, Object expected, string reason)
        {
            try
            {
                Assert.AreNotEqual(actual, expected, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        ///  Assert that the text contains expected string.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public void AssertThatContainsString(string actual, string expected)
        {
            try
            {
                Assert.ByVal(actual, Contains.Substring(expected));
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that the text contains expected string.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="reason"></param>
        public void AssertThatContainsString(string actual, string expected, string reason)
        {
            try
            {
                Assert.ByVal(actual, Contains.Substring(expected), reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that condition is true.
        /// </summary>
        /// <param name="condition"></param>
        public void AssertThatIsTrue(bool condition)
        {
            try
            {
                Assert.IsTrue(condition);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="reason"></param>
        public void AssertThatIsTrue(bool condition, string reason)
        {
            try
            {
                Assert.IsTrue(condition, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that condition is false.
        /// </summary>
        /// <param name="condition"></param>
        public void AssertThatIsFalse(bool condition)
        {
            try
            {
                Assert.IsFalse(condition);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="reason"></param>
        public void AssertThatIsFalse(bool condition, string reason)
        {
            try
            {
                Assert.IsFalse(condition, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that object is null.
        /// </summary>
        /// <param name="condition"></param>
        public void AssertThatIsNull(Object condition)
        {
            try
            {
                Assert.IsNull(condition);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that object is null.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="reason"></param>
        public void AssertThatIsNull(Object condition, string reason)
        {
            try
            {
                Assert.IsNull(condition, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that object is not null.
        /// </summary>
        /// <param name="condition"></param>
        public void AssertThatIsNotNull(Object condition)
        {
            try
            {
                Assert.IsNotNull(condition);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Assert that object is not null.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="reason"></param>
        public void AssertThatIsNotNull(Object condition, string reason)
        {
            try
            {
                Assert.IsNotNull(condition, reason);
            }
            catch (Exception e)
            {
                softAssertChain.AddFailure(e);
            }
        }

        /// <summary>
        /// Examines this asset chain for failures and if any detected writes each exception into console output.
        /// Resets asserts state for the next step/scenarion thats uses soft assertions.
        /// </summary>
        public void ProcessAsserts()
        {
            try
            {
                if (softAssertChain.GetFailures().IsEmpty())
                {
                    return;
                }
                else
                {
                    foreach (Exception failure in softAssertChain.GetFailures())
                    {
                        logger.Debug(string.Format("Exception: Failure: {0} Message: {1}", failure.ToString(), failure.Message));
                    }

                    string message = string.Format("There were {0} exception(s) during execution",
                        softAssertChain.GetFailures().Count);

                    logger.Debug(message);

                    throw new Exception(message);
                }
            }
            finally
            {
                softAssertChain.Reset();
            }
        }
    }
}

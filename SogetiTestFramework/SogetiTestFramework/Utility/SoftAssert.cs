using System;
using NUnit.Framework;

namespace SogetiTestFramework.Utility
{
    public class SoftAssert
    {
        private SoftAssertChain softAssertChain = new SoftAssertChain();

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
                        Console.Error.WriteLine(failure);
                    }
                    throw new Exception("There were " + softAssertChain.GetFailures().Count + " exception(s) during execution");
                }
            }
            finally
            {
                softAssertChain.Reset();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace SogetiTestFramework.Utility
{
    public class SoftAssertChain
    {
        private BaseList<Exception> failures;

        public SoftAssertChain()
        {
            failures = new BaseList<Exception>();
        }

        public void AddFailure(Exception failure)
        {
            this.failures.Add(failure);
        }

        public void Reset()
        {
            this.failures.Clear();
        }

        public BaseList<Exception> GetFailures()
        {
            return this.failures;
        }
    }
}

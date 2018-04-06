using System.Collections.Generic;

namespace SogetiTestFramework.Utility
{
    /// <summary>
    /// This class expands functionality of List<T> class.
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>3 Apr 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class BaseList<T> : List<T>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}

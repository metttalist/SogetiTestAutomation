using System.Collections.Generic;

namespace SogetiTestFramework.Utility
{
     public class BaseList<T> : List<T>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}

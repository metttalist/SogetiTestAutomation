using System.Collections.Generic;
using System.Threading;

namespace SogetiTestFramework.Utility
{
    /// <summary>
    /// This class is used to track the list of items for a scenario that were stored globally and can be accessed form different step definition classes. 
    /// </summary>
    /// <author>Igor Khorev</author>
    /// <date>24 Apr 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class Globals
    {

        private ThreadLocal<Dictionary<string, object>> globalValues = new ThreadLocal<Dictionary<string, object>>();

        /// <summary>
        /// Resets storage.
        /// </summary>
        public void Clear()
        {
            globalValues.Value = null;
        }

        /// <summary>
        /// Adds an objects to the dictionary.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            GetDictionary().Add(key, value);
        }

        /// <summary>
        /// Adds an object to a list of objects associated with this key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddToList(string key, object value)
        {
            Dictionary<string, object> dictionary = GetDictionary();
            BaseList<object> values;
            if (dictionary.ContainsKey(key))
            {
                values = (BaseList<object>)dictionary[key];
            }
            values = new BaseList<object>();
            dictionary.Add(key, values);


            values.Add(value);
        }

        /// <summary>
        /// Removes the object from a list of objects associated with this key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void RemoveFromList(string key, object value)
        {
            Dictionary<string, object> dictionary = GetDictionary();
            BaseList<object> values;
            if (dictionary.ContainsKey(key))
            {
                values = (BaseList<object>)dictionary[key];
                if (values != null)
                {
                    values.Remove(value);
                }
            }
        }

        /// <summary>
        /// Returns the object mathing this key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (GetDictionary().ContainsKey(key))
            {
                return (T)GetDictionary()[key];
            }
            return default(T);
        }

        /// <summary>
        /// Determines whether the dictionary contains the cpecified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return GetDictionary().ContainsKey(key);
        }

        /// <summary>
        /// Internal method used to return a thred-local dictionary and initilize it if not yet initilized.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> dictionary = globalValues.Value;
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
                globalValues.Value = dictionary;
            }

            return dictionary;
        }
    }
}

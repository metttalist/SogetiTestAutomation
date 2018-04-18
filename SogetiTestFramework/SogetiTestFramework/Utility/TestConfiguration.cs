using System;

namespace SogetiTestFramework.Utility
{
    /// <summary>
    /// This class provides the base test execution properties. This configuration designed to 
    /// be avaible for all applications in the solution.
    /// </summary>
    /// <author>Chris Macgowan</author>
    /// <date>28 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class TestConfiguration
    {
        protected ConfigurationManager configurationManager;

        // The following values are common framework properties. 
        
        // The TestConfiguration object is created when the application under test 
        // creates and object from framework base classes:  object from BasePage, 
        // BaseRestClient or BaseStepDefinition. 

        // Platform     
        private string platformOS;
        private string platformVersion;

        // Browser
        private string browserType;
        private string browserVersion;
        private int browserTimeoutSeconds;

        // Application 
        private string applicationName;
        private string applicationComment;
        private string applicationURL;

        // User
        private string userName;
        private string userPassword;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestConfiguration()
        {
            // Create the configurationManager object and read the file. If the 
            // file does not exist a default file will be created and an exception will 
            // be thrown to warn the user. 
            configurationManager = new ConfigurationManager();
            configurationManager.ReadConfigFile();

            // set the test configuration values
            
            // Platform     
            platformOS = configurationManager.GetPlatformOS();
            platformVersion = configurationManager.GetPlatformVersion();

            // Browser
            browserType = configurationManager.GetBrowserType();
            browserVersion = configurationManager.GetBrowserVersion();
            browserTimeoutSeconds = Int32.Parse(configurationManager.GetBrowserTimeoutSeconds());

            // Application 
            applicationName = configurationManager.GetApplicationName();
            applicationComment = configurationManager.GetApplicationComment();
            applicationURL = configurationManager.GetApplicationURL();

            // User
            userName = configurationManager.GetUserName();
            userPassword = configurationManager.GetUserPassword();
        }

        #region Platform configuration  
        // Platform configuration

        /// <summary>
        /// Get the platform OS
        /// </summary>
        /// <returns>string platform OS</returns>
        public string GetPlatformOS()
        {
            return platformOS;
        }

        /// <summary>
        /// Get the platform version
        /// </summary>
        /// <returns>string platform version</returns>
        public string GetPlatformVersion()
        {
            return platformVersion;
        }
        #endregion

        #region Browser configuration
        // Browser configuration

        /// <summary>
        /// Get the browser type
        /// </summary>
        /// <returns>string browser type</returns>
        public string GetBrowserType()
        {
            return browserType;
        }

        /// <summary>
        /// Get the browser version
        /// </summary>
        /// <returns>string browser version</returns>
        public string GetBrowserVersion()
        {
            return browserVersion;
        }

        /// <summary>
        /// Get the browser timeout in seconds
        /// </summary>
        /// <returns>int browser timeout in seconds</returns>
        public int GetBrowserTimeoutSeconds()
        {
            return browserTimeoutSeconds;
        }
        #endregion

        #region Application configuration
        // Application configuration

        /// <summary>
        /// Get the application name
        /// </summary>
        /// <returns>string application name</returns>
        public string GetApplicationName()
        {
            return applicationName;
        }

        /// <summary>
        /// Get the application comment
        /// </summary>
        /// <returns>string application comment</returns>
        public string GetApplicationComment()
        {
            return applicationComment;
        }

        /// <summary>
        /// Get the application URL
        /// </summary>
        /// <returns>string application URL</returns>
        public string GetApplicationURL()
        {
            return applicationURL;
        }
        #endregion

        #region User configuration
        // User configuration

        /// <summary>
        /// Get the user name
        /// </summary>
        /// <returns>string user name</returns>
        public string GetUserName()
        {
            return userName;
        }

        /// <summary>
        /// Get the user password
        /// </summary>
        /// <returns>string user password</returns>
        public string GetUserPassword()
        {
            return userPassword;
        }
        #endregion

    }
}

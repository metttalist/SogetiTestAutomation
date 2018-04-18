using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using SogetiTestFramework.Helper;

namespace SogetiTestFramework.Utility
{

    /// <summary>
    /// This class provides support to read and write to the application configuration file.
    /// We are using an independent JSON configuration file.
    /// 
    /// If the configuration file is not present a default configuration will be created using 
    /// the default constants below. 
    /// 
    /// The default configuration file is setup to support the UI test (SampleTestProject). The 
    /// default configuration will not support the API test. When a new configuration file is 
    /// created by this class the API configuration will need to be updated.
    /// 
    /// When the configuration file is not found and a new default file is created, an exception 
    /// will be thrown to alert the user that a new default configuration file has been created 
    /// and will need to be updated. 
    /// </summary>
    /// <author>Chris Macgowan</author>
    /// <date>11 Apr 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class ConfigurationManager
    {
        private static readonly Log logger = new Log(typeof(ConfigurationManager));

        // Default values when we create the config file

        // Filename
        private const string DefaultAutomationConfigFileName = "AppAutomationConfig.json";

        // Platform     
        private const string DefaultPlatformOS = "Linux";
        private const string DefaultPlatformVersion = "12.34";

        // Browser
        private const string DefaultBrowserType = Constants.BrowserTypeChrome;
        private const string DefaultBrowserVersion = "22.6";
        private const int DefaultBrowserTimeoutSeconds = Constants.BrowserTimeoutSeconds;

        // Application 
        private const string DefaultApplicationName = "General UI Test - Sample Test Project";
        private const string DefaultApplicationComment = "UI test cases to test framework components (SampleTestProject)";
        private const string DefaultApplicationURL = "https://google.com";

        // User
        private const string DefaultUserName = "jstrummer";
        private const string DefaultUserPassword = "dre!@juTime";

        // JSON object with configuration data
        protected JObject appConfigJObject;

        // Automation configuration file location
        private string automationConfigFileName;


        /// <summary>
        /// Default constructor
        /// </summary>
        public ConfigurationManager()
        {
            logger.Debug("--------------------------------------------------------------------------------");
            logger.Debug("Start the automation process (this might be the first place we come");

            // We will read from the project folder
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            automationConfigFileName = projectPath + DefaultAutomationConfigFileName;

            string message = string.Format("Configuration file: {0}",
                    automationConfigFileName);

            logger.Debug("Create the ConfigurationManager object.");
            logger.Debug(message);
        }


        /// <summary>
        /// This will read the application config file into memory 
        /// We might want to just put this in the constrcutor
        /// </summary>
        public void ReadConfigFile()
        {
            try
            {
                // read JSON directly from a file
                logger.Debug("Read configuration file.");
                using (StreamReader file = File.OpenText(automationConfigFileName))
                using (JsonTextReader jsonTextReader = new JsonTextReader(file))
                {
                    appConfigJObject = (JObject)JToken.ReadFrom(jsonTextReader);
                }

                WriteConfigurationToLog(); 
            }
            catch (FileNotFoundException ex)
            {
                // Configuration file not found

                // Create a default configuration file when none found
                CreateDefaultConfigFile();

                string errorMessage = string.Format("The Automation Application Configuration file was not found. " +
                    "The test will end. A default file will be created with default values. The configuration " +
                    "should be updated. Configuration file location: {0} Exception message: {1}",
                    automationConfigFileName, 
                    ex.Message);

                logger.Error(errorMessage);

                throw new System.Exception(errorMessage);
            }
            catch (Exception ex)
            {
                // Handle a general exception
                
                string errorMessage = string.Format("An exception was handled while reading the Automation Application " +
                    "Configuration file. The test will end. Have a nice day. Exception message: {0}",
                    ex.Message);

                logger.Error(errorMessage);

                throw new System.Exception(errorMessage);
            }
        }


        /// <summary>
        /// The CreateDefaultConfigFile() will create a default configuration file. This 
        /// method will be called when we attempt to read the configuration file and 
        /// it does not exist. 
        /// </summary>
        private void CreateDefaultConfigFile()
        {
            // create the default JSON configuration file
            
            try
            {
                logger.Debug("Create default configuration file.");
                JObject platform = new JObject(
                new JProperty("platformOS", DefaultPlatformOS),
                new JProperty("platformVersion", DefaultPlatformVersion));

                JObject browser = new JObject(
                new JProperty("browserType", DefaultBrowserType),
                new JProperty("browserVersion", DefaultBrowserVersion),
                new JProperty("browserTimeoutSeconds", DefaultBrowserTimeoutSeconds.ToString()));

                JObject application = new JObject(
                new JProperty("applicationName", DefaultApplicationName),
                new JProperty("applicationComment", DefaultApplicationComment),
                new JProperty("applicationURL", DefaultApplicationURL));

                JObject user = new JObject(
                new JProperty("userName", DefaultUserName),
                new JProperty("userPassword", DefaultUserPassword));

                JObject configurationRoot = new JObject(
                new JProperty("platform", platform),
                new JProperty("browser", browser),
                new JProperty("application", application),
                new JProperty("user", user));

                File.WriteAllText(automationConfigFileName, JToken.FromObject(configurationRoot).ToString());

                using (StreamReader file = File.OpenText(automationConfigFileName))
                using (JsonTextReader jsonTextReader = new JsonTextReader(file))
                {
                    appConfigJObject = (JObject)JToken.ReadFrom(jsonTextReader);
                }

                WriteConfigurationToLog();
            }
            catch (JsonException ex)
            {
                // Json exception
                
                string errorMessage = string.Format("A JSON exception was handled while creating the reading " +
                    "the Automation Application Configuration file. The test will end. Have a nice day. Exception message: {0}",
                    ex.Message);

                logger.Error(errorMessage);

                throw new System.Exception(errorMessage);
            }
            catch (Exception ex)
            {
                // Handle general exception
                
                string errorMessage = string.Format("An exception was handled while creating the Automation Application " +
                    "Configuration file. The test will end. Have a nice day. Exception message: {0}",
                    ex.Message);

                logger.Error(errorMessage);

                throw new System.Exception(errorMessage);
            }
        }

        /// <summary>
        /// The WriteConfigurationToLog() method will write the current configuration to 
        /// the Log object. 
        /// </summary>
        private void WriteConfigurationToLog()
        {
            logger.Debug("Current application configuration settings.");

            // Application platform
            logger.Debug(string.Format("Platform OS: {0}", GetPlatformOS()));
            logger.Debug(string.Format("Platform Version: {0}", GetPlatformVersion()));

            // Browser
            logger.Debug(string.Format("Browser Type: {0}", GetBrowserType()));
            logger.Debug(string.Format("Browser Version: {0}", GetBrowserVersion()));
            logger.Debug(string.Format("Browser Timeout (sec): {0}", GetBrowserTimeoutSeconds()));

            // Application Name
            logger.Debug(string.Format("Application Name: {0}", GetApplicationName()));
            logger.Debug(string.Format("Application Comment: {0}", GetApplicationComment()));
            logger.Debug(string.Format("Application URL: {0}", GetApplicationURL()));

            // User configuration 
            logger.Debug(string.Format("User Name: {0}", GetUserName()));
            logger.Debug(string.Format("User Password: {0}", GetUserPassword()));
        }

        #region Platform configuration
        // Platform configuration

        /// <summary>
        /// Get the platform OS value from the json configuration object
        /// </summary>
        /// <returns>string platform OS</returns>
        public string GetPlatformOS()
        {
            return (string)appConfigJObject["platform"]["platformOS"];
        }

        /// <summary>
        /// Get the platform version value from the json configuration object
        /// </summary>
        /// <returns>string platform version</returns>
        public string GetPlatformVersion()
        {
            return (string)appConfigJObject["platform"]["platformVersion"];
        }
        #endregion

        #region Browser configuration
        // Browser configuration

        /// <summary>
        /// Get the browser type value from the json configuration object
        /// </summary>
        /// <returns>string browser type</returns>
        public string GetBrowserType()
        {
            return (string)appConfigJObject["browser"]["browserType"];
        }

        /// <summary>
        /// Get the browser version value from the json configuration object
        /// </summary>
        /// <returns>string browser version</returns>
        public string GetBrowserVersion()
        {
            return (string)appConfigJObject["browser"]["browserVersion"];
        }

        /// <summary>
        /// Get the browser timeout in seconds value from the json configuration object
        /// </summary>
        /// <returns>string browser timeout seconds</returns>
        public string GetBrowserTimeoutSeconds()
        {
            return (string)appConfigJObject["browser"]["browserTimeoutSeconds"];
        }
        #endregion

        #region Application configuration
        // Application configuration

        /// <summary>
        /// Get the application name value from the json configuration object
        /// </summary>
        /// <returns>string application name</returns>
        public string GetApplicationName()
        {
            return (string)appConfigJObject["application"]["applicationName"];
        }

        /// <summary>
        /// Get the application comment value from the json configuration object
        /// </summary>
        /// <returns>string application comment</returns>
        public string GetApplicationComment()
        {
            return (string)appConfigJObject["application"]["applicationComment"];
        }

        /// <summary>
        /// Get the application URL value from the json configuration object
        /// </summary>
        /// <returns>string application URL</returns>
        public string GetApplicationURL()
        {
            return (string)appConfigJObject["application"]["applicationURL"];
        }
        #endregion

        #region User configuration
        // User configuration

        /// <summary>
        /// Get the user name value from the json configuration object
        /// </summary>
        /// <returns>string user name</returns>
        public string GetUserName()
        {
            return (string)appConfigJObject["user"]["userName"];
        }

        /// <summary>
        /// Get the user password value from the json configuration object
        /// </summary>
        /// <returns>string user password</returns>
        public string GetUserPassword()
        {
            return (string)appConfigJObject["user"]["userPassword"];
        }
        #endregion
    }
}

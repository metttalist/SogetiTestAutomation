
using RestSharp;
using RestSharp.Authenticators;
using SogetiTestFramework.Helper;
using SogetiTestFramework.Utility;
using System;
using System.Net;

namespace SogetiTestFramework.Rest
{
    /// <summary>
    /// This class will provide REST support.
    /// </summary>
    /// <author>Jeff Bertram</author>
    /// <date>April 10, 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    public class BaseRestClient
    {
        private static readonly Log logger = new Log(typeof(BaseRestClient));

        protected TestConfiguration testConfiguration = new TestConfiguration();

        protected SoftAssert softAsseert = new SoftAssert();

        /// <summary>
        ///   Given the url, username and password the request will be sent and the content will be returned
        ///   as a string.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Content string</returns>
        public string Get(string url, string username, string password)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            client.Authenticator = new SimpleAuthenticator("username", username, "password", password);
            var response = client.Execute(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Content.ToString();
            }
            return string.Format("The Rest Get API failed with a status of {0}", response.StatusCode);
        }

        /// <summary>
        /// Given the url, username and password the request will be sent and the IRestResponse 
        /// returned.
        /// 
        /// This is the same implementation of the Get method as below - other than we are 
        /// returning the IRestResponse. Also note that the header parameter was added only 
        /// to make the method signature different than the other Get method.
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="header"></param>
        /// <returns>Content IRestResponse</returns>
        public IRestResponse Get(string url, string username, string password, string header)
        {
            IRestResponse response = new RestResponse();

            try
            {
                IRestClient client = new RestClient(url);

                IRestRequest request = new RestRequest(Method.GET);
                
                client.Authenticator = new SimpleAuthenticator("username", username, "password", password);

                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Error;
                response.ErrorMessage = ex.Message;
                response.ErrorException = ex;
            }

            return response;
        }

        /// <summary>
        ///   Given the url and token the request will be sent and the content will be returned
        ///   as a string.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns>Content string</returns>
        public string Get(string url, string token)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", token);
            var response = client.Execute(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Content.ToString();
            }
            return string.Format("The Rest Get API failed with a status of {0}", response.StatusCode);
        }

        /// <summary>
        ///   Given the url and token the request will be sent and the data will be returned
        ///   as a data object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns>Return the data object</returns>
        public T Get<T>(string url, string token) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", token);
            var response = client.Execute<T>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Data;
            }
            return default(T);
        }

        /// <summary>
        ///   Given the url, token and body the request will be sent and the data will be returned
        ///   as a data object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <returns>Return the data object</returns>
        public T Post<T>(string url, string token, T body) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("token", token);
            request.AddBody(body);
            var response = client.Execute<T>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Data;
            }
            return default(T);
        }

        /// <summary>
        ///   Given the url, token and body the request will be sent and the data will be returned
        ///   as a data object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <returns>Return the data object</returns>
        public T Put<T>(string url, string token, T body) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("token", token);
            request.AddBody(body);
            var response = client.Execute<T>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Data;
            }
            return default(T);
        }
    }
}

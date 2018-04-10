using RestSharp;
using RestSharp.Authenticators;
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
        public BaseRestClient()
        {
        }

        /// <summary>
        ///   Given the url, username and password the request will be sent and the content will be returned
        ///   as a string.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Content string</returns>
        public string GetMethod(string url, string username, string password)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            client.Authenticator = new SimpleAuthenticator("username", username, "password", password);
            var queryResult = client.Execute(request);

            if (queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                return queryResult.Content.ToString();
            }
            return string.Format("The Rest Get API failed with a status of {0}", queryResult.StatusCode);
        }

        /// <summary>
        ///   Given the url and token the request will be sent and the content will be returned
        ///   as a string.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns>Content string</returns>
        public string GetMethod(string url, string token)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", token);
            var queryResult = client.Execute(request);

            if (queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                return queryResult.Content.ToString();
            }
            return string.Format("The Rest Get API failed with a status of {0}", queryResult.StatusCode);
        }

        /// <summary>
        ///   Given the url and token the request will be sent and the data will be returned
        ///   as a data object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns>Return the data object</returns>
        public T GetMethod<T>(string url, string token) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", token);
            var queryResult = client.Execute<T>(request);

            if (queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                return queryResult.Data;
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
        public T PostMethod<T>(string url, string token, T body) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("token", token);
            request.AddBody(body);
            var queryResult = client.Execute<T>(request);

            if (queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                return queryResult.Data;
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
        public T PutMethod<T>(string url, string token, T body) where T : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("token", token);
            request.AddBody(body);
            var queryResult = client.Execute<T>(request);

            if (queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                return queryResult.Data;
            }
            return default(T);
        }
    }
}

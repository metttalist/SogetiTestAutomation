using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SogetiTestFramework.Rest
{
    public class BaseRestClient
    {
        public BaseRestClient()
        {

        }

        public string GetMethod(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var queryResult = client.Execute(request);

            if (queryResult.ResponseStatus.Equals(HttpStatusCode.OK))
            {
                return queryResult.Content.ToString();
            }
            return string.Format("The Rest Get API failed with a status of {0}", queryResult.ResponseStatus);
        }

        public void PostMethod()
        {
            var client = new RestClient("http://192.168.0.1");
            var request = new RestRequest("api/item/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            //request.AddBody(new Item
            //{
            //    ItemName = someName,
            //    Price = 19.99
            //});
            client.Execute(request);
        }

        public void Post2()
        {
            //var request = new RestRequest("resource/{id}", Method.POST);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            //// easily add HTTP Headers
            //request.AddHeader("header", "value");

            //// add files to upload (works with compatible verbs)
            ////request.AddFile(path);

            //// execute the request
            //IRestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            //// easy async support
            //client.ExecuteAsync(request, response => 
            //{
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => 
            //{
            //    Console.WriteLine(response.Data.Name);
            //});

        }

    /// <summary>
    /// This class will provide REST support.
    /// </summary>
    /// <author></author>
    /// <date>28 Mar 2018</date>
    /// <copyright>
    /// All rights reserved by Capgemini. Copyright © 2018 Capgemini. Proprietary and 
    /// Confidential information of Capgemini. Disclosure, Use or Reproduction 
    /// without the written authorization of Capgemini is prohibited.
    /// </copyright>
    class BaseRestClient
    {
    }
}

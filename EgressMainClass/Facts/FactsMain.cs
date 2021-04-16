using RestSharp;
using System;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace EgressMainClass.Facts
{
    public class FactsMain
    {
        //Initialize
        AuthClass authClass = new AuthClass();
        private string Url = "https://egressassessmentapi20210323143024.azurewebsites.net";

        //Get Facts 
        public Tuple<int, string> getFacts()
        {
            authClass.gettingToken();

            var restClient = new RestClient(Url);

            var restRequest = new RestRequest("/egress/facts", Method.GET); //Getting all members 
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken); //Header with auth token 
            
            //Response 
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);

            //Storing Status code and content in Tuple 
            int status = (int)response.StatusCode;
            string content = (string)response.Content;
            
            //returning Tuple.
            return new Tuple<int, string>(status, content);

        }

        //Adding fact
        public Tuple<int, string> postFacts()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/facts", Method.POST);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);

            //Adding Json Body with id and Description
            restRequest.AddJsonBody(new {id = 19, description = "NTest -19"}); 
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);

        }

        //Getting fact by id
        public Tuple<int, string> getFactById()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/facts/{id}", Method.GET); //Method to get fact by Id
           var a =  restRequest.AddUrlSegment("id", 1); //Adding id to the url 
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken); //Header with token 
            
            var response = restClient.Execute(restRequest);
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);
        }

        // Update Fact
        public Tuple<int, string> putFact()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/facts/{id}", Method.PUT);
            var a = restRequest.AddUrlSegment("id", 12);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new { id = 12, description = "Changed again at "+ DateTime.Now });
            var response = restClient.Execute(restRequest);
            int status = (int)response.StatusCode;


            var restRequestAfterPut = new RestRequest("/egress/facts/{id}", Method.GET);
            var addingId = restRequestAfterPut.AddUrlSegment("id", 12);
            restRequestAfterPut.AddHeader("Authorization", "Bearer " + authClass.authToken);
            var responseAfterPut = restClient.Execute(restRequestAfterPut);
            
            string content = (string)responseAfterPut.Content;

            return new Tuple<int, string>(status, content);
        }

        //Delete Facts
        public Tuple<int, string> deleteFacts()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/facts/{id}", Method.DELETE);
            var a = restRequest.AddUrlSegment("id", 14);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new {id = 14});
            var response = restClient.Execute(restRequest);
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);
        }

    }
}

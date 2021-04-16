using RestSharp;
using System;

namespace EgressMainClass.Members
{
   public class MembersMain
    {

        AuthClass authClass = new AuthClass();
        private string Url = "https://egressassessmentapi20210323143024.azurewebsites.net";

        //Get members method
        public Tuple<int, string> getMembers()
        {
            //Calling auth method to get the token 
            authClass.gettingToken();

            var restClient = new RestClient(Url);

            var restRequest = new RestRequest("/egress/members", Method.GET); //Get method to get all members
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken); //Adding token to the header

            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest); //Execute the request

            //Storing status code and content to Tuple and returing them. 
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);

        }

        //Adding member
        public Tuple<int, string> postMembers()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/members", Method.POST); //Post method to add member
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new { id = 6, name = "User6" , title = "Test"}); //Adding Json Body to add member with id, name and title
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);

        }

        //Get members bt ID
        public Tuple<int, string> getMembersById()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/members/{id}", Method.GET); //Get method for members with specific ID
            var a = restRequest.AddUrlSegment("id", 1); //Adding id to the url 
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            
            var response = restClient.Execute(restRequest);

            //Storing status code and Content to Tuple 
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            //Returning Tuple.
            return new Tuple<int, string>(status, content);
        }
        //Updating member
        public Tuple<int, string> putMembers()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/members/{id}", Method.PUT); //PUt method to update member
            var a = restRequest.AddUrlSegment("id", 6);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);

            //Adding Json body with ID name and Title with  Date/time when it is updated. 
            restRequest.AddJsonBody(new { id = 6, name = " Updated at " + DateTime.Now , title = " Updated at " + DateTime.Now});
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;

            //Calling Get method again to check if updated correctly. 
            var restRequestAfterPut = new RestRequest("/egress/members/{id}", Method.GET);
            var addingId = restRequestAfterPut.AddUrlSegment("id", 6);
            restRequestAfterPut.AddHeader("Authorization", "Bearer " + authClass.authToken);
            var responseAfterPut = restClient.Execute(restRequestAfterPut);

            string content = (string)responseAfterPut.Content;

            return new Tuple<int, string>(status, content);
        }

        //Delete members 
        public Tuple<int, string> deleteMembers()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/members/{id}", Method.DELETE); //Delete method to delete a member
            var a = restRequest.AddUrlSegment("id", 5);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new { id = 5 });
            var response = restClient.Execute(restRequest);


            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);
        }

    }
}


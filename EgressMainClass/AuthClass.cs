using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace EgressMainClass
{




    public class AuthClass
    {

        public string authToken;
        public void gettingToken()
        {
            
            var restClient = new RestClient("https://egressassessmentapi20210323143024.azurewebsites.net");

            var restRequest = new RestRequest("/egress/authenticate", Method.POST);
            restRequest.AddJsonBody(new { username = "user", password = "test1234" });

            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);

            var deserialise = new JsonDeserializer();
            var output = deserialise.Deserialize<Dictionary<string, string>>(response);
            var token = output["token"];

            authToken = token.ToString();

            //restRequest.AddHeader("Authorization", "Bearer " + authToken);



        }


    }
}

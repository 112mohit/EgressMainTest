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

            //Auth 
            var restRequest = new RestRequest("/egress/authenticate", Method.POST); //Post method to pass username and pass

            //Adding username and pass to Json Body
            restRequest.AddJsonBody(new { username = "user", password = "test1234" });

            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);

            //Getting Token
            var deserialise = new JsonDeserializer();
            var output = deserialise.Deserialize<Dictionary<string, string>>(response);
            var token = output["token"];

            authToken = token.ToString();


        }


    }
}

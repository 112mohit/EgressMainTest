using RestSharp;
using System;

namespace EgressMainClass.Products
{
   public class ProductsMain
    {

        //Initializee
        AuthClass authClass = new AuthClass();

        //URL
        private string Url = "https://egressassessmentapi20210323143024.azurewebsites.net";

        //Get Products method
        public Tuple<int, string> getProducts()
        {

            //Calling Auth method to get the token, 
            authClass.gettingToken();

            var restClient = new RestClient(Url);
            //End point and calling get method 
            var restRequest = new RestRequest("/egress/products", Method.GET);

            //Adding bearer and token to the header 
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);

            //Response
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);

            //Storing in Tuple to return status code and content to the test method. 
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);

        }

        //Post Method for Adding products
        public Tuple<int, string> postProducts()
        {
           
            authClass.gettingToken();
            var restClient = new RestClient(Url); //URL
            var restRequest = new RestRequest("/egress/products", Method.POST); //POST method with the end point

            //Adding bearer and token to the header
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);

            //Adding Jason body for product. Id, name and description. 
            restRequest.AddJsonBody(new { id = 8, name = "Test Product 8" , description = "Test Product 8 description"});
            var response = restClient.Execute(restRequest);

            //Storing in Tuple and return status code and content to test method. 
            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);

        }

        public Tuple<int, string> getProductsById()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/products/{id}", Method.GET);

            //Adding Id to the url 
            var a = restRequest.AddUrlSegment("id", 1); 
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);           
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);
        }

        public Tuple<int, string> putProduct()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/products/{id}", Method.PUT);
            var a = restRequest.AddUrlSegment("id", 8);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new { id = 8, name = "Updated Product 8 name",description = "Product 8 description Changed again at " + DateTime.Now });
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;

            //Calling get method again to check if product is updated. 
            var restRequestAfterPut = new RestRequest("/egress/products/{id}", Method.GET);
            var addingId = restRequestAfterPut.AddUrlSegment("id", 8);
            restRequestAfterPut.AddHeader("Authorization", "Bearer " + authClass.authToken);
            var responseAfterPut = restClient.Execute(restRequestAfterPut);

            string content = (string)responseAfterPut.Content;

            return new Tuple<int, string>(status, content);

        }

        public Tuple<int, string> deleteProduct()
        {
            authClass.gettingToken();
            var restClient = new RestClient(Url);
            var restRequest = new RestRequest("/egress/products/{id}", Method.DELETE); //Calling delete mthod to delete a  product.
            var a = restRequest.AddUrlSegment("id", 7);
            restRequest.AddHeader("Authorization", "Bearer " + authClass.authToken);
            restRequest.AddJsonBody(new { id = 7 });
            var response = restClient.Execute(restRequest);

            int status = (int)response.StatusCode;
            string content = (string)response.Content;

            return new Tuple<int, string>(status, content);
        }

    }
}

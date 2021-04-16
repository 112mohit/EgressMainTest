using EgressMainClass.Facts;
using NUnit.Framework;
using RestSharp;
using System;


namespace EgressTests
{

    public class FactsTests
    {
        //Initilazation
        public FactsMain factsMain;
        RestClient restClient = new RestClient();

        //Get all facts 
        [Test]
        public void getFacts()
        {

            factsMain = new FactsMain();
            //Calling get facts 
            var result = factsMain.getFacts();
            //Getting data from Tuple
            int status = result.Item1;
            string content = result.Item2;

            //If status code is 200 and Content is not null then pass. 
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        //Adding a fact
        [Test]
        public void AddFacts()
        {
            factsMain = new FactsMain();
            //Calling post facts method 
            var result = factsMain.postFacts();
            //Getting fata from Tuple
            int status = result.Item1;
            string content = result.Item2;

            //If status code 201 and content not null then pass else check the other errors. 

            if (status == 201 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("New Fact Added");
            }
            else if (status == 500 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id already exists in the API");
            }
            else
            {
                Assert.Fail("Fact not added");
            }
        }

        //Getting fact by id 
        [Test]
        public void getFactsById()
        {
            factsMain = new FactsMain();

            var result = factsMain.getFactById();
            int status = result.Item1;
            string content = result.Item2;

            //If status code 200 and string not null then pass otherwise check for other error. 
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Fact Recieved");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id not found in the API");
            }
            else
            {
                Assert.Fail("Fact not added");
            }
        }

        //Updating fact 
        [Test]       
        public void putFact()
        {
            factsMain = new FactsMain();

            var result = factsMain.putFact();
            int status = result.Item1;
            string content = result.Item2;

            //If status code 204 then pass, as it is not documeneted
            if (status == 204 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Code not documented but, Fact Updated");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id and Json body Id was not same");
            }
            else
            {
                Assert.Fail("Fact not updated");
            }
        }

       //Delete fact
        [Test]
        public void deleteFact()
        {
            factsMain = new FactsMain();

            var result = factsMain.deleteFacts();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Fact deleted");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id not found");
            }
            else
            {
                Assert.Fail("Fact not updated");
            }
        }

    }
}

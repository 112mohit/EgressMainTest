using EgressMainClass.Members;
using NUnit.Framework;
using RestSharp;
using System;

namespace EgressTests
{
   public class MembersTests
    {
        //Initilaization 
        public MembersMain membersMain = new MembersMain() ;
        
        RestClient restClient = new RestClient();

        //Get all members 
        [Test]
        public void getMembers()
        {

            var result = membersMain.getMembers();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Member Details received");
            }
            else
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail();
            }
        }

        //Adding member
        [Test]
        public void postMembers()
        {
            

            var result = membersMain.postMembers();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 201 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("New Member Added");
            }
            else if (status == 500 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id already exists in the API");
            }
            else
            {
                Assert.Fail("Member not added");
            }
        }

        //Get members by id
        [Test]
        public void getMembersById()
        {
            

            var result = membersMain.getMembersById();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Member Details Recieved");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id not found in the API");
            }
            else
            {
                Assert.Fail("Member details not recieved");
            }
        }

        //updating members
        [Test]
        public void putMembers()
        {
           
            var result = membersMain.putMembers();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 204 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Code not documented but, Member Updated");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id and Json body Id was not same");
            }
            else
            {
                Assert.Fail("Member not updated");
            }
        }

        //Delete members 
        [Test]
        public void deleteMembers()
        {
            
            var result = membersMain.deleteMembers();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Member deleted");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id not found");
            }
            else
            {
                Assert.Fail("Member not deleted");
            }
        }

    }
}

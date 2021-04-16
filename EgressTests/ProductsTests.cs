using EgressMainClass.Products;
using NUnit.Framework;
using RestSharp;
using System;

namespace EgressTests
{
   public class ProductsTests
    {
        //Initalization 
        public ProductsMain productsMain = new ProductsMain();

        RestClient restClient = new RestClient();

        //Getting all products
        [Test]
        public void getProducts()
        {

            var result = productsMain.getProducts();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Product Details received");
            }
            else
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail();
            }
        }


        //Post Products 
        [Test]
        public void postProducts()
        {


            var result = productsMain.postProducts();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 201 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("New Product Added");
            }
            else if (status == 500 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because Product id already exists in the API");
            }
            else
            {
                Assert.Fail("Product not added");
            }
        }

        //get products by id
        [Test]
        public void getProductById()
        {


            var result = productsMain.getProductsById();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Product Details Recieved");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because product id not found in the API");
            }
            else
            {
                Assert.Fail("Product details not recieved");
            }
        }

        //Updating products 
        [Test]
        public void putProducts()
        {

            var result = productsMain.putProduct();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 204 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Code not documented but, Product Updated");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id and Json body Id was not same");
            }
            else
            {
                Assert.Fail("Product not updated");
            }
        }

        //Delete Products. 
        [Test]
        public void deleteProduct()
        {

            var result = productsMain.deleteProduct();
            int status = result.Item1;
            string content = result.Item2;
            if (status == 200 && string.IsNullOrEmpty(content) == false)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Pass("Product deleted");
            }
            else if (status == 404 && string.IsNullOrEmpty(content) == true)
            {
                Console.WriteLine("Content: " + content);
                Console.WriteLine("Response Status: " + status);
                Assert.Fail("Failed because id not found");
            }
            else
            {
                Assert.Fail("Product not deleted");
            }
        }
    }
}

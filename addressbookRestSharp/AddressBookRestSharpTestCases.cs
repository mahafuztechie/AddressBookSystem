using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace addressbookRestSharp
{
    public class Contacts
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
    [TestClass]
    public class AddressBookRestSharpTestCases
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:3000");
        }

        private RestResponse GetAddressList()
        {
            // arrange
            RestRequest request = new RestRequest("/Contacts", Method.Get);

            // act
            RestResponse response = client.ExecuteAsync(request).Result;
            return response;
        }

        [TestMethod]
        public void OnCallingGETApi_ReturnAddressList()
        {
            RestResponse response = GetAddressList();

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(1, dataResponse.Count);
        }

        [TestMethod]
        public void GivenAddressBook_DoPost_ShouldReturnAddedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/Contacts", Method.Post);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
            new
            {
             
                firstname= "Kylie",
                lastname= "McMiller",
                address= "Sidewalk 3/41",
                city= "Lockenwille",
                state= "WoodLer",
                zip= 521432,
                phone= 7548965265,
                email= "kylie@gmail.com"

             });
            // act
            RestResponse response = client.ExecuteAsync(request).Result;

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("Kylie", dataResponse.firstname);
            Assert.AreEqual("McMiller", dataResponse.lastname);
            Assert.AreEqual("Sidewalk 3/41", dataResponse.address);
            Assert.AreEqual("Lockenwille", dataResponse.city);
            Assert.AreEqual("WoodLer", dataResponse.state);
            Assert.AreEqual(521432, dataResponse.zip);
            Assert.AreEqual(7548965265, dataResponse.phone);
            Assert.AreEqual("kylie@gmail.com", dataResponse.email);
        }

        [TestMethod]
        public void GivenAddressBook_OnPut_ShouldReturnUpdatedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/Contacts/2", Method.Put);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
            new
            {
                firstname = "elon",
                lastname = "musk",
                address = "canada",
                city = "abc",
                state = "xyz",
                zip = 56789,
                phone = 9988776655,
                email = "elon@musk.com"

            });
            // act
            RestResponse response = client.ExecuteAsync(request).Result;

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("elon", dataResponse.firstname);
            Assert.AreEqual("elon@musk.com", dataResponse.email);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientAssistance;
using PatientAssistance.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PatientAssistance.Tests.Controllers
{
    [TestClass]
    public class UtilsTest
    {

        [TestMethod]
        public void GetAPIResponseTest()
        {
            // Arrange
            Utils utils = new Utils();
            var request = (HttpWebRequest.Create("http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals"));
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            // Act
            var result = utils.GetAPIResponse("http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals");

            // Assert
            Assert.AreEqual(result, responseString);
        }

        [TestMethod]
        public void ParseObjectDetailsTest()
        {
            // Arrange
            Utils utils = new Utils();
            var request = (HttpWebRequest.Create("http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals"));
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            // Act
            var result = utils.ParseObjectDetails(responseString);

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetHospitalListTest()
        {
            // Arrange
            Utils utils = new Utils();

            // Act
            var result = utils.GetHospitalList();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetIllnessListTest()
        {
            // Arrange
            Utils utils = new Utils();

            // Act
            var result = utils.GetIllnessList();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

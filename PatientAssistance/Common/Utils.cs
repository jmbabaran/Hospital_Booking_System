using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientAssistance.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace PatientAssistance.Common
{
    public class Utils
    {

 
        public string GetAPIResponse( string url)
        {
            var request = (HttpWebRequest.Create(url));
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public JToken ParseObjectDetails(string response)
        {
            dynamic respObj = JsonConvert.DeserializeObject(response); //  Converted
            var jObj = (JObject)respObj;

            var embedded = jObj.First;
            var item = (JObject)embedded.First;
            var itempList = item.First;
            JToken itemDetails = itempList.First;

            return itemDetails;
        }


        public List<Hospital> GetHospitalList ()
        {
            List<Hospital> hospitalList = new List<Hospital>();

            var responseString = this.GetAPIResponse("http://dmmw-api.australiaeast.cloudapp.azure.com:8080/hospitals");

            var hospDetails = ParseObjectDetails(responseString);

            foreach (JToken token in hospDetails.Children())
            {
                Hospital hospitalTemp = JsonConvert.DeserializeObject<Hospital>(token.ToString());
                hospitalList.Add(hospitalTemp);

            }

            return hospitalList;

        }


        public List<Illness> GetIllnessList()
        {
            List<Illness> illnessList = new List<Illness>();

            var responseString = this.GetAPIResponse("http://dmmw-api.australiaeast.cloudapp.azure.com:8080/illnesses");

            var illnessDetails = ParseObjectDetails(responseString);

            foreach (JToken token in illnessDetails.Children())
            {
                var ill = token.First;
                var illProp = ill.First;

                Illness illnessTemp = JsonConvert.DeserializeObject<Illness>(illProp.ToString());
                illnessList.Add(illnessTemp);

            }

            return illnessList;

        }

    }
}
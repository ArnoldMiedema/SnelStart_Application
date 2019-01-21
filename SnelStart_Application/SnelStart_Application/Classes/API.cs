using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SnelStart.B2B.Client;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SnelStart_Application.Classes
{
    class API
    {
        private string subscriptionKey = "2d9a56339cc3449cae56c4bee0fcc357";
        private string clientKey = "dW45WC92T29SUVBxbUVvWjhzSVZCbGt1aXFnMnBMK1BGK3RabzBjQXFSaWx1TU1ibUNFMHoyMzJ4dzlnbEE5K0Q4eHZzZngrUmZRTDIwQmJwdjZuamw1aU16SnpjSzQxQ3Vac003SUZpUjdTMC94TXNmVXNxQVl3V1dXZTlDSmh1OGw1Y1J6dU9jV3JCMlk5ZUNVRUJRZkhtSWNaZnpxY1NENWxVZlpST0ZhOFFKR05FYzZtQ2xqczJKYjNxc1lUZU52S0xTMEdzb1l0dGxWWGhrdmFFNUp6emNNajA4bGFBYmJ0Tk5iZlA5SnVMdnQ4L1MxT1N4Sno2OHdqa3JHUjp2dGtIdUxzOVdsdkJna2l1S1UrbDFrVDJUZG5UbU1DOHRNWGN6cEs1L1FoMS8waWpOWS9XTEI0NFo2czkwdG5kZE1meU5kWlp6S0tENzArakVoMVFCOStMNUI0RHdMcHIvQWcyS01IOXpMZnM2S3FnVUo1Zm9XbXovZ08vZWpQeXNRYlF4L1VpeVNRNFR2cjR5MkdUaU10Rk1XRmxXcHBaWXVYdWViYTdaYjJpWVZYd0lvQ3Jpd2o1R0Vkd1F6Q0tDR0Q5WnlNYTJvWnZaSXNBcGIveGJkVkNNb2NEbnY4WGFJcjhNZEk3SUhTVlZuRHhQV05nMmhtU0k4RnFWc3Iw";


        public string snelstartAPI()
        {
            if (string.IsNullOrEmpty(clientKey) || string.IsNullOrEmpty(subscriptionKey))
            {
                return "werkt niet";
            }
            else
            {
                var bearerToken = GetBearerToken(clientKey);
                return bearerToken;
            }            
        }

        private static string GetBearerToken(string clientkey)
        {
            using (var httpClient = new HttpClient())
            {
                Dictionary<string, string> requestBody = new Dictionary<string, string>();
                requestBody.Add("grant_type", "clientkey");
                requestBody.Add("clientkey", clientkey);

                Uri requestUri = new Uri("https://auth.snelstart.nl/b2b/token");

                var message = httpClient.PostAsync(requestUri, new FormUrlEncodedContent(requestBody)).Result;
                var json = message.Content.ReadAsStringAsync().Result;
                dynamic response = JObject.Parse(json);

                return response.access_token;
            }
        }

        public List<Customer> GetCustomers(string bearerToken)
        {
            List<Customer> CustList = new List<Customer>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}"); 
                var result = httpClient.GetAsync(new Uri("https://b2bapi.snelstart.nl/v1/relaties?$filter=Relatiesoort/any(r:r eq 'Klant')")).Result;/*https://b2bapi.snelstart.nl/v1/verkoopfacturen */
                var json = result.Content.ReadAsStringAsync().Result;
                dynamic response = JArray.Parse(json);
                for(int i = 0; i <  response.Count; i++)
                {
                    Customer Cust = new Customer();
                    Cust.Name = response[i].naam;
                    Cust.CustomerID = response[i].id;
                    CustList.Add(Cust);
                }
            }
            return CustList;
        }

        public void GetBoughtProducts(string bearerToken, string CustomerID)
        {
            List<Customer> CustList = new List<Customer>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                string url = "https://b2bapi.snelstart.nl/v1/verkooporders?";//retrieve verkooporders
                var result = httpClient.GetAsync(new Uri(url)).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                dynamic response = JArray.Parse(json);
                Console.WriteLine(response[0].regels.artikel.id);
                //for (int i = 0; i < response.Count; i++)
                //{
                //    string url2 = "https://b2bapi.snelstart.nl/v1/artikelen?$filter=id "+ response[i].regels.artikel.id +"";//use information from Verkoopboekingen to retrieve products inside the boekingen
                //    var result2 = httpClient.GetAsync(new Uri(url2)).Result;
                //    var json2 = result2.Content.ReadAsStringAsync().Result;
                //    Customer Cust = new Customer();
                //    Cust.Name = response[i].naam;
                //    CustList.Add(Cust);
                //}
            }
            //return CustList;
        }

        
    }
}

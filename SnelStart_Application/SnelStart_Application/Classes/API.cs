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
        public void snelstartAPI()
        {
            var clientKey = "dW45WC92T29SUVBxbUVvWjhzSVZCbGt1aXFnMnBMK1BGK3RabzBjQXFSaWx1TU1ibUNFMHoyMzJ4dzlnbEE5K0Q4eHZzZngrUmZRTDIwQmJwdjZuamw1aU16SnpjSzQxQ3Vac003SUZpUjdTMC94TXNmVXNxQVl3V1dXZTlDSmh1OGw1Y1J6dU9jV3JCMlk5ZUNVRUJRZkhtSWNaZnpxY1NENWxVZlpST0ZhOFFKR05FYzZtQ2xqczJKYjNxc1lUZU52S0xTMEdzb1l0dGxWWGhrdmFFNUp6emNNajA4bGFBYmJ0Tk5iZlA5SnVMdnQ4L1MxT1N4Sno2OHdqa3JHUjp2dGtIdUxzOVdsdkJna2l1S1UrbDFrVDJUZG5UbU1DOHRNWGN6cEs1L1FoMS8waWpOWS9XTEI0NFo2czkwdG5kZE1meU5kWlp6S0tENzArakVoMVFCOStMNUI0RHdMcHIvQWcyS01IOXpMZnM2S3FnVUo1Zm9XbXovZ08vZWpQeXNRYlF4L1VpeVNRNFR2cjR5MkdUaU10Rk1XRmxXcHBaWXVYdWViYTdaYjJpWVZYd0lvQ3Jpd2o1R0Vkd1F6Q0tDR0Q5WnlNYTJvWnZaSXNBcGIveGJkVkNNb2NEbnY4WGFJcjhNZEk3SUhTVlZuRHhQV05nMmhtU0k4RnFWc3Iw";
            var subscriptionKey = "2d9a56339cc3449cae56c4bee0fcc357";

            if (string.IsNullOrEmpty(clientKey) || string.IsNullOrEmpty(subscriptionKey))
            {
                Console.WriteLine("De variabelen apiKey en de clientkey moeten een waarde hebben");
            }
            else
            {
                var bearerToken = GetBearerToken(clientKey);
                GetEigenRelatie(subscriptionKey, bearerToken);
                GetFacturen(subscriptionKey, bearerToken);
            }
        }

        private static void GetEigenRelatie(string subscriptionKey, string bearerToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                var result = httpClient.GetAsync(new Uri("https://b2bapi.snelstart.nl/v1/relaties?$filter=Relatiesoort/any(r:r eq 'Eigen')")).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                dynamic response = JArray.Parse(json);
                Console.WriteLine(response[0].naam);
            }
        }

        private static void GetFacturen(string subscriptionKey, string bearerToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                var result = httpClient.GetAsync(new Uri("https://b2bapi.snelstart.nl/v1/verkoopfacturen")).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                dynamic response = JArray.Parse(json);
                Customer test = new Customer();
                test.Name = response[1].id;
                Console.WriteLine(test.Name);
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
    }
}

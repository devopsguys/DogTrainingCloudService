using DogTrainingWeb.Models;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DogTrainingWeb.Tests.Integration
{
    [TestFixture]
    public class DogTrainingWebTests
    {
        public const string GetLatestBarkApiPath = "api/DogBarkApi/GetLatest";
        public const string PostBarkApiPath = "api/DogBarkApi/Post";

        private readonly string BarkCloudServiceUrl = ConfigurationManager.AppSettings["BarkCloudServiceUrl"];
        private readonly string DogTrainingSecret = ConfigurationManager.AppSettings["DogTrainingSecret"];

        [Test]
        public void MainPageReturnsHttpOK()
        {
            var request = WebRequest.Create(BarkCloudServiceUrl);
            var response = (HttpWebResponse)request.GetResponse();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void ApiReturnsLatestBark()
        {
            var latestBark = CallApiGet<DogBarkModel>(GetLatestBarkApiPath).Result;
            if (latestBark == null)
            {
                PostTestBark().Wait();
                latestBark = CallApiGet<DogBarkModel>(GetLatestBarkApiPath).Result;
            }
            Assert.IsNotNull(latestBark);
        }

        private async Task PostTestBark()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BarkCloudServiceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var bark = new DogBarkViewModel { Bark = "Integration Test Bark", Secret = DogTrainingSecret };
                var response = await client.PostAsJsonAsync(PostBarkApiPath, bark);
            }
        }

        private async Task<T> CallApiGet<T>(string apiPath)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BarkCloudServiceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiPath);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<T>() : default(T);
            }
        }
    }
}

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

        private readonly string BarkCloudServiceUrl = ConfigurationManager.AppSettings["BarkCloudServiceUrl"];

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
            var latestBark = CallApiGet<DogBarkModel>(GetLatestBarkApiPath).GetAwaiter().GetResult();
            Assert.IsNotNull(latestBark);
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

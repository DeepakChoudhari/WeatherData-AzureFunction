namespace WeatherDataFunctionApp
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    public static class WeatherDataService
    {
        private static readonly HttpClient WeatherDataHttpClient = new HttpClient();

        private static readonly string ApiUrl; 

        static WeatherDataService()
        {
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            ApiUrl = $"https://api.apixu.com/v1/current.json?key={apiKey}&q={{0}}";
        }

        [FunctionName("WeatherDataService")]
        public static async Task<HttpResponseMessage> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var queryNameValuePairs = req.GetQueryNameValuePairs();
            var location = queryNameValuePairs.Where(pair => pair.Key.Equals("location", StringComparison.InvariantCultureIgnoreCase)).Select(queryParam => queryParam.Value).FirstOrDefault();

            HttpResponseMessage responseMessage = await GetCurrentWeatherDataForLocation(location);

            if (responseMessage.IsSuccessStatusCode)
                return req.CreateResponse(HttpStatusCode.OK, responseMessage.Content.ReadAsAsync(typeof(object)).Result);

            log.Error($"Error occurred while trying to retrieve weather data for {req.Content.ReadAsStringAsync().Result}");
            return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error.");
        }

        private static async Task<HttpResponseMessage> GetCurrentWeatherDataForLocation(string location)
        {
            return await WeatherDataHttpClient.GetAsync(String.Format(ApiUrl, location));
        }
    }
}

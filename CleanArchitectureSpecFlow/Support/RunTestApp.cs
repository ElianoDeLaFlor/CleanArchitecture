using Microsoft.AspNetCore.Mvc;


namespace CleanArchitectureSpecFlow.Support
{
    [Binding]
    public class RunTestApp
    {
        private static WebAppFactory<Program> _webAppFactory;
        private static HttpClient _httpClient;
        private static HttpResponseMessage _httpResponse;
        private static IActionResult _response;


        [BeforeScenario]
        public void Setup()
        {
            _webAppFactory = new WebAppFactory<Program>();
            _httpClient = _webAppFactory.CreateDefaultClient();
            _httpResponse = new HttpResponseMessage();
            //_httpClient.BaseAddress = new Uri(_webAppFactory.Server.BaseAddress, "/api/");
        }

        public static HttpClient GetHttpClient() => _httpClient;
        public static HttpResponseMessage GetHttpResponse() => _httpResponse;
    }
}

using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Response;
using CleanArchitectureSpecFlow.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CleanArchitectureSpecFlow.StepDefinitions
{
    [Binding]
    public class ImmobilierStepDefinitions
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponse;
        private ImmobilierDto _ImmobilierDto=new();

        private WebAppFactory<Program> _appFactory;
        

        string _immobilierId=string.Empty;
        string _immobilierReff=string.Empty;
        public ImmobilierStepDefinitions()
        {
            _appFactory = new WebAppFactory<Program>();
            _httpClient = _appFactory.CreateClient();
            _httpResponse = new();
        }

        [Given(@"there are Immobolier in the system")]
        public void GivenThereAreImmobolierInTheSystem()
        {
            //throw new PendingStepException();
        }

        [When(@"I make a POST request on '([^']*)' with this data:")]
        public async Task WhenIMakeAPOSTRequestOnWithThisData(string url, Table table)
        {
           var immobilier = table.Rows[0].CreateInstance<ImmobilierDto>();
            _ImmobilierDto = immobilier;
            var content=new StringContent(JsonConvert.SerializeObject(immobilier),Encoding.UTF8,MediaTypeNames.Application.Json);
            
            _httpResponse = await _httpClient.PostAsync(url, content);
        }

        [Then(@"a successful response is returned with the newly added Immobolier")]
        public async Task ThenASuccessfulResponseIsReturnedWithTheNewlyAddedImmobolier()
        {
            var response= await _httpResponse.Content.ReadFromJsonAsync<ServiceResponse<Immobilier>>();

            Assert.Equal(response?.Data?.Avance, _ImmobilierDto.Avance);
            Assert.Equal(response?.Data?.Prix, _ImmobilierDto.Prix);
            Assert.IsAssignableFrom<ServiceResponse<Immobilier>>(response);
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int p0)
        {
            Assert.Equal(p0,(int)_httpResponse.StatusCode);
        }

        [When(@"I make a GET request on '([^']*)'")]
        public async Task WhenIMakeAGETRequestOn(string url)
        {
            _httpResponse = await _httpClient.GetAsync(url);
            
        }

        [Then(@"a successful response is returned with a list of Immobolier")]
        public async Task ThenASuccessfulResponseIsReturnedWithAListOfImmobolier()
        {
            var response = await _httpResponse.Content.ReadFromJsonAsync<ServiceResponse<List<Immobilier>>>();

            Assert.IsAssignableFrom<ServiceResponse<List<Immobilier>>>(response);
            Assert.Equal(true, response?.Success);
            Assert.Equal(3, response?.Data?.Count);
        }

        [Given(@"The immobilier Id is '([^']*)'")]
        public void GivenTheImmobilierIdIs(string id)
        {
            _immobilierId = id;
        }

        [Then(@"a successful response is returned with the the retrieved immobillier data")]
        public async Task ThenASuccessfulResponseIsReturnedWithTheTheRetrievedImmobillierData()
        {
            var response = await _httpResponse.Content.ReadFromJsonAsync<ServiceResponse<Immobilier>>();

            Assert.IsAssignableFrom<ServiceResponse<Immobilier>>(response);
            Assert.Equal(true, response?.Success);
            Assert.Equal("98765432-10fe-dcba-0987-6543210fedcba",response?.Data?.Id );
        }

        [When(@"I make a GET request on '([^']*)' endpoint")]
        public async Task WhenIMakeAGETRequestOnEndpoint(string url)
        {
            _httpResponse = await _httpClient.GetAsync(url + "/" + _immobilierId);
        }

        [Given(@"The immobilier Reff is '([^']*)'")]
        public void GivenTheImmobilierReffIs(string reff)
        {
            _immobilierReff = reff;
        }

        [When(@"I made a GET request on '([^']*)' endpoint with the reff")]
        public async Task WhenIMadeAGETRequestOnEndpointWithTheReff(string url)
        {
            _httpResponse = await _httpClient.GetAsync(url + "/" + _immobilierReff);
        }


    }
}

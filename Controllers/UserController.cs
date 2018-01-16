using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projekt.Controllers.Resources;
using RestSharp;

namespace projekt.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private string apiToken;
        private RestClient client;
        private string baseUri = "https://dtas.auth0.com/api/v2/users";

        public UserController()
        {
            apiToken = GetApiToken();
            client = new RestClient();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            client.BaseUrl = new Uri(baseUri);

            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + apiToken);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return Ok(response.Content);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id) {
            var uri = baseUri.ToString() + "/" + id;
            client.BaseUrl = new Uri(uri);

            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + apiToken);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return Ok(response.Content);

            return NotFound();
        }

        
        private string GetApiToken()
        {
            var client = new RestClient("https://dtas.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"grant_type\":\"client_credentials\",\"client_id\": \"XCYycsyU1lPWL1bdXHmwj6Bw349Z7VKO\",\"client_secret\": \"lHYXsEbTkrYyER-J8pRyv4tbKxNVOWcF5GvNJ7CNmLjq7P-GWuOdn2IffVcDYLE3\",\"audience\": \"https://dtas.auth0.com/api/v2/\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<TokenResource>(response.Content);

            return result.access_token;
        }
    }
}
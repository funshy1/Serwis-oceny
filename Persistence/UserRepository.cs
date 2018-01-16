using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using projekt.Controllers.Resources;
using projekt.Models;
using RestSharp;

namespace projekt.Persistence
{
    public class UserRepository : IUserRepository
    {
        private string apiToken;
        private RestClient client;
        private string baseUri = "https://dtas.auth0.com/api/v2/users";
        private readonly ILogger logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            this.logger = logger;
            apiToken = GetApiToken();
            client = new RestClient();
        }
        public User GetUser(string id)
        {

            var uri = baseUri.ToString() + "/" + id;
            client.BaseUrl = new Uri(uri);
            var result = new User();

            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + apiToken);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                result = JsonConvert.DeserializeObject<User>(response.Content);

            return result;
        }

        public QueryResult<User> GetUsers()
        {
            client.BaseUrl = new Uri(baseUri);
            var result = new QueryResult<User>();

            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + apiToken);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content);
            result.Items = users;
            result.TotalItems = users.Count;

            return result;
        }

        public User UpdateUser(SaveUserResource user, string id)
        {
            var uri = baseUri.ToString() + "/" + id;
            client.BaseUrl = new Uri(uri);


            var request = new RestRequest(Method.PATCH);

            request.AddHeader("authorization", "Bearer " + apiToken);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);

            logger.LogInformation("USER PATCH REQUEST WITH CREDENTIALS: " + JsonConvert.SerializeObject(user));

            IRestResponse response = client.Execute(request);

            logger.LogInformation(response.Content);

            return GetUser(id);
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
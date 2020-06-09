using Microsoft.Extensions.Configuration;
using Scores.Library.Soccer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Scores.Library.HttpClients.Soccer
{
    public class SoccerClient : ISoccerClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public SoccerClient(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;
            client.BaseAddress = new Uri(_configuration.GetSection("SoccerData").Value);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GetSection("Footbal-Data Key").ToString());
            _httpClient = client;
        }

        public async Task<List<Competition>> SoccerCompetitions()
        {
            string errorString;

            CompetitionCollection jsonCompetitionCollection = new CompetitionCollection();

            try
            {
                jsonCompetitionCollection = await _httpClient.GetFromJsonAsync<CompetitionCollection>("/v2/competitions/?plan=TIER_ONE");
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting Competitions: {ex.Message}";
            }

           List<Competition> competitions = new List<Competition>(jsonCompetitionCollection.Competitions);

            return competitions;


        }
    }
}

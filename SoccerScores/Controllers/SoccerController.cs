using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Scores.Library.HttpClients.Soccer;
using Scores.Library.Models.Soccer;
using ScoresUI.ViewModels;

namespace ScoresUI.Controllers
{
    public class SoccerController : Controller
    {
        
        private readonly ILogger<SoccerController> _logger;
        private readonly ISoccerClient _soccerClient;
        private readonly IConfiguration _config;

        public SoccerController(ILogger<SoccerController> logger, ISoccerClient soccerClient, IConfiguration config)
        {
            _soccerClient = soccerClient;
            _config = config;
            _logger = logger;
        }
        public async Task<ViewResult> GetCompetitions()
        {
            var data = await _soccerClient.SoccerCompetitions();

            SoccerScoresViewModel competitionCollectionViewModel = new SoccerScoresViewModel();

            competitionCollectionViewModel.Competitions = AddCompetitionLogo(data);
            competitionCollectionViewModel.PageTitle = "Soccer Competitions";


            return View(competitionCollectionViewModel);


        }

        // Move to library
        private Dictionary<string, string> LoadLogos()
        {
            return _config.GetSection("SoccerCompetitionLogos").Get<Dictionary<string, string>>();
        }

        private List<Competition> AddCompetitionLogo(List<Competition> competitions)
        {
            List<Competition> data = new List<Competition>(competitions);

            Dictionary<string, string> logos = LoadLogos();

            foreach (Competition comp in data)
            {
                if (String.IsNullOrEmpty(comp.emblemUrl))
                {
                    if (logos.ContainsKey(comp.code))
                    {
                        comp.emblemUrl = logos[comp.code];
                    }
                }
            }

            return data; 
        }
    }
}

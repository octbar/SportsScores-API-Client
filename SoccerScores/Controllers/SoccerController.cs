using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scores.Library.HttpClients.Soccer;
using ScoresUI.ViewModels;

namespace ScoresUI.Controllers
{
    public class SoccerController : Controller
    {
        
        private readonly ILogger<SoccerController> _logger;
        private readonly ISoccerClient _soccerClient;

        public SoccerController(ILogger<SoccerController> logger, ISoccerClient soccerClient)
        {
            _soccerClient = soccerClient;
            _logger = logger;
        }
        public async Task<ViewResult> GetCompetitions()
        {
            var data = await _soccerClient.SoccerCompetitions();

            SoccerScoresViewModel competitionCollectionViewModel = new SoccerScoresViewModel();

            competitionCollectionViewModel.Competitions = data;
            competitionCollectionViewModel.PageTitle = "Soccer Competitions";


            return View(competitionCollectionViewModel);


        }
    }
}

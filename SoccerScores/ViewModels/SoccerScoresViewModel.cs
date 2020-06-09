using Scores.Library.Soccer.Models;
using System.Collections.Generic;

namespace ScoresUI.ViewModels
{
    public class SoccerScoresViewModel
    {
        public List<Competition> Competitions { get; set; }
        public string PageTitle { get; set; }
    }
}

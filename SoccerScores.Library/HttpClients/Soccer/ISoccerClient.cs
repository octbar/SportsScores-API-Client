using Scores.Library.Soccer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scores.Library.HttpClients.Soccer
{
    public interface ISoccerClient
    {
        Task<List<Competition>> SoccerCompetitions();
    }
}
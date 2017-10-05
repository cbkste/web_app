using System.Collections.Generic;
using web_app.LolEsportsModels;
using web_app.Model;
using web_app.ViewModels;

namespace web_app.Extensions.ViewModelExtensions
{
    public static class LolEsportsTeamsViewModelExtension
    {
        public static LolEsportsTeamViewModel ToLolEsportsTeamViewModel(this Team response)
        {
            var teams = new List<LolEsportsTeams>();
            var players = new List<LolEsportsPlayer>();

            response.TeamInfo.ForEach(t => teams.Add(t));
            response.Players.ForEach(p => players.Add(p));

            return new LolEsportsTeamViewModel
            {
                Teams = teams,
                Players = players
            };
        }
    }
}

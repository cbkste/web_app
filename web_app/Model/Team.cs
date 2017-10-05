using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.LolEsportsModels;

namespace web_app.Model
{
    public class Team
    {
        public string Title { get; }
        public List<LolEsportsTeams> TeamInfo { get; }
        public List<LolEsportsPlayer> Players { get; }

        public Team(List<LolEsportsTeams> teamInfo, List<LolEsportsPlayer> players)
        {
            TeamInfo = teamInfo;
            Players = players;
        }
    }
}
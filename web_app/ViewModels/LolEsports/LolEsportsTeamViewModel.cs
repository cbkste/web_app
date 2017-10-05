using System.Collections.Generic;
using web_app.LolEsportsModels;

namespace web_app.ViewModels
{
    public class LolEsportsTeamViewModel
    {
        public List<LolEsportsTeams> Teams { get; set; } = null;
        public List<LolEsportsPlayer> Players { get; set; } = null;
    }
}

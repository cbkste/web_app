using System.Collections.Generic;

namespace web_app.LolEsportsModels
{
    public class LolEsportsTeam
    {
        public List<LolEsportsPlayer> Players { get; set; } = null;
        public List<LolEsportsTeams> Teams { get; set; } = null;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.ILolEsportsFactory;
using web_app.LolEsportsModels;
using web_app.Model;

namespace web_app.LolEsportsFactories
{
    public class TeamLolEsportsFactory : ILolEsportsFactory<LolEsportsTeam, Team>
    {
        public Team ToModel(LolEsportsTeam teamData)
        {

            List<LolEsportsTeams> teams = teamData.Teams.Select(t => new LolEsportsTeams(t.Id,t.Name,t.TeamPhotoUrl,t.LogoUrl,t.Aacronymme, t.HomeLeague, t.AltLogoUrl)).ToList();
            List<LolEsportsPlayer> players = teamData.Players.Select(t => new LolEsportsPlayer(t.Id, t.Slug, t.Name, t.FirstName, t.LastName, t.RoleSlug, t.PhotoUrl, t.Hometown, t.Region, t.Birthdate, t.SocialNetworks, t.Bios)).ToList();

            return new Team(teams, players);
        }
    }
    }


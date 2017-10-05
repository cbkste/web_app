namespace web_app.LolEsportsModels
{
    public class LolEsportsTeams
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string TeamPhotoUrl { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Aacronymme { get; set; } = string.Empty;
        public string HomeLeague { get; set; } = string.Empty;
        public string AltLogoUrl { get; set; } = string.Empty;

        public LolEsportsTeams(int id, string name, string teamPhotoUrl, string logoUrl, string aacronymme, string homeLeague, string altLogoUrl)
        {
            Id = id;
            Name = name;
            TeamPhotoUrl = teamPhotoUrl;
            LogoUrl = logoUrl;
            Aacronymme = aacronymme;
            HomeLeague = homeLeague;
            AltLogoUrl = altLogoUrl;
        }
    }
}

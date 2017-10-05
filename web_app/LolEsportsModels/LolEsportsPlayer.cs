using System.Collections.Generic;

namespace web_app.LolEsportsModels
{
    public class LolEsportsPlayer
    {
        public int Id { get; set; } = 0;
        public string Slug { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RoleSlug { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string Hometown { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Birthdate { get; set; } = null;
        public LolESportsSocialNetwork SocialNetworks { get; set; } = null;
        public LolEsportsBiosLanguage Bios { get; set; } = null;

        public LolEsportsPlayer (int id, string slug, string name, string firstName, string lastName, string roleSlug, string photoUrl, string hometown, string region, string birthdate, LolESportsSocialNetwork socialNetworks, LolEsportsBiosLanguage bios)
        {
            Id = id;
            Slug = slug;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            RoleSlug = roleSlug;
            PhotoUrl = photoUrl;
            Hometown = hometown;
            Region = region;
            Birthdate = birthdate;
            SocialNetworks = socialNetworks;
            Bios = bios;
        }
    }
}

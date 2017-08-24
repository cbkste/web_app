using System.Collections.Generic;
using web_app.Gateways.Responses;

namespace web_app.ViewModels
{
    public class TwitchTopClipsForGameViewModel
    {
        public List<Clip> Clips { get; set; }
        public string _cursor { get; set; }
    }
}

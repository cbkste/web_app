using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Gateways.Responses
{
    public class TwitchTopClipsForGame
    {
        public List<Clip> Clips { get; set; }
        public string _cursor { get; set; }
    }
}

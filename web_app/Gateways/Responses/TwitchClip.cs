using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Gateways.Responses
{
    public class Clip
    {
        public string slug { get; set; }
        public string tracking_id { get; set; }
        public string url { get; set; }
        public string embed_url { get; set; }
        public string embed_html { get; set; }
        public Broadcaster broadcaster { get; set; }
        public Curator curator { get; set; }
        public Vod vod { get; set; }
        public string broadcast_id { get; set; }
        public string game { get; set; }
        public string language { get; set; }
        public string title { get; set; }
        public int views { get; set; }
        public double duration { get; set; }
        public string created_at { get; set; }
        public Thumbnails thumbnails { get; set; }
    }

}

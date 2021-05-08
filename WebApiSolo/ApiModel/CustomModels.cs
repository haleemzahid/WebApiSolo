using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSolo.ApiModel
{
    public class Odds
    {
        public List<double> h2h { get; set; }
        public List<double> h2h_lay { get; set; }
    }

    public class Site
    {
        public string site_key { get; set; }
        public string site_nice { get; set; }
        public int last_update { get; set; }
        public Odds odds { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string sport_key { get; set; }
        public string sport_nice { get; set; }
        public List<string> teams { get; set; }
        public int commence_time { get; set; }
        public string home_team { get; set; }
        public List<Site> sites { get; set; }
        public int sites_count { get; set; }
    }

    public class Upcomming_Data
    {
        public bool success { get; set; }
        public List<Datum> data { get; set; }
    }
}

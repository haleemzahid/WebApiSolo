using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class SiteDatum
    {
        public long Id { get; set; }
        public string Site { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string League { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeWin { get; set; }
        public string Draw { get; set; }
        public string AwayWin { get; set; }
        public string SiteUniqueId { get; set; }
        public long? SiteId { get; set; }

        public virtual TblSite SiteNavigation { get; set; }
    }
}

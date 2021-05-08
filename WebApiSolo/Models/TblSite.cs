using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TblSite
    {
        public TblSite()
        {
            SiteData = new HashSet<SiteDatum>();
            TblUserSites = new HashSet<TblUserSite>();
        }

        public long SiteId { get; set; }
        public string SiteName { get; set; }

        public virtual ICollection<SiteDatum> SiteData { get; set; }
        public virtual ICollection<TblUserSite> TblUserSites { get; set; }
    }
}

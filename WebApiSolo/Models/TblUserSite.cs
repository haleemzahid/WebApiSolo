using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TblUserSite
    {
        public long UserSitesId { get; set; }
        public long SiteId { get; set; }
        public long UserId { get; set; }

        public virtual TblSite Site { get; set; }
        public virtual TblUser User { get; set; }
    }
}

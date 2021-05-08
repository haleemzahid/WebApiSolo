using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TblUserRole
    {
        public long UserRoleId { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual TblUser User { get; set; }
    }
}

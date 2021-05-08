using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUserRoles = new HashSet<TblUserRole>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
    }
}

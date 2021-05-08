using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblUserRoles = new HashSet<TblUserRole>();
            TblUserSites = new HashSet<TblUserSite>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public Guid? UserUid { get; set; }

        public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
        public virtual ICollection<TblUserSite> TblUserSites { get; set; }
    }
}

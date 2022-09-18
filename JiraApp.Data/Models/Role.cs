using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleAssginments = new HashSet<RoleAssginment>();
        }

        public int RoleId { get; set; }
        public int TenantId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<RoleAssginment> RoleAssginments { get; set; }
    }
}

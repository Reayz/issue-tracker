using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class RoleAssginment
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string AssignedBy { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}

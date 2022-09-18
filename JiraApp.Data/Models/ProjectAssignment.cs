using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class ProjectAssignment
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int ProjectRoleId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string AssginedBy { get; set; } = null!;

        public virtual Project Project { get; set; } = null!;
        public virtual ProjectRole ProjectRole { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}

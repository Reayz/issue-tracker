using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class ProjectRole
    {
        public ProjectRole()
        {
            ProjectAssignments = new HashSet<ProjectAssignment>();
        }

        public int ProjectRoleId { get; set; }
        public int TenantId { get; set; }
        public string ProjectRoleName { get; set; } = null!;

        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
    }
}

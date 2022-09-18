using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            AllCredentialHistories = new HashSet<AllCredentialHistory>();
            AppCredentials = new HashSet<AppCredential>();
            ProjectAssignments = new HashSet<ProjectAssignment>();
            RoleAssginments = new HashSet<RoleAssginment>();
        }

        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<AllCredentialHistory> AllCredentialHistories { get; set; }
        public virtual ICollection<AppCredential> AppCredentials { get; set; }
        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
        public virtual ICollection<RoleAssginment> RoleAssginments { get; set; }
    }
}

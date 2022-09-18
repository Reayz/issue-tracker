using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class AllCredentialHistory
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }

        public virtual AppUser User { get; set; } = null!;
    }
}

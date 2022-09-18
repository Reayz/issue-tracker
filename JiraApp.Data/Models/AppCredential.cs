using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class AppCredential
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ConnectionKey { get; set; }
        public string? Dbname { get; set; }
        public string? SubdomainName { get; set; }

        public virtual AppUser User { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class TenantGroup
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string ClientName { get; set; } = null!;
        public string? ConnectionKey { get; set; }
        public string? Dbname { get; set; }
        public string? SubdomainName { get; set; }
    }
}

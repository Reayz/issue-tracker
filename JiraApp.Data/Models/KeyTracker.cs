using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class KeyTracker
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public string LookupKey { get; set; } = null!;
        public int NextKey { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}

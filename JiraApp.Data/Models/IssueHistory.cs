using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class IssueHistory
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int IssueId { get; set; }
        public string UpdatedField { get; set; } = null!;
        public string OldValue { get; set; } = null!;
        public string NewValue { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Issue Issue { get; set; } = null!;
    }
}

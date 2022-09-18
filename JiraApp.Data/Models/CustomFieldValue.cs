using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class CustomFieldValue
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int IssueId { get; set; }
        public int FieldId { get; set; }
        public string FieldValue { get; set; } = null!;
        public DateTime ValueSetDate { get; set; }
        public string ValueSetBy { get; set; } = null!;

        public virtual CustomField Field { get; set; } = null!;
        public virtual Issue Issue { get; set; } = null!;
    }
}

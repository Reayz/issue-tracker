using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class CustomField
    {
        public CustomField()
        {
            CustomFieldValues = new HashSet<CustomFieldValue>();
        }

        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public string FieldName { get; set; } = null!;
        public string FieldType { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? DefaultValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }
    }
}

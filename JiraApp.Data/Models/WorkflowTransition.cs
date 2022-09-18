using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class WorkflowTransition
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int StatusFromId { get; set; }
        public int StatusToId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual WorkflowStatus StatusFrom { get; set; } = null!;
        public virtual WorkflowStatus StatusTo { get; set; } = null!;
    }
}

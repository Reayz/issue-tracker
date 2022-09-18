using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class WorkflowStatus
    {
        public WorkflowStatus()
        {
            WorkflowTransitionStatusFroms = new HashSet<WorkflowTransition>();
            WorkflowTransitionStatusTos = new HashSet<WorkflowTransition>();
        }

        public int TemplateId { get; set; }
        public int TenantId { get; set; }
        public int StatusId { get; set; }
        public string StatusText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual WorkflowTemplate Template { get; set; } = null!;
        public virtual ICollection<WorkflowTransition> WorkflowTransitionStatusFroms { get; set; }
        public virtual ICollection<WorkflowTransition> WorkflowTransitionStatusTos { get; set; }
    }
}

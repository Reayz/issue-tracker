using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class WorkflowTemplate
    {
        public WorkflowTemplate()
        {
            WorkflowAssignments = new HashSet<WorkflowAssignment>();
            WorkflowStatuses = new HashSet<WorkflowStatus>();
        }

        public int TemplateId { get; set; }
        public int TenantId { get; set; }
        public string TemplateName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<WorkflowAssignment> WorkflowAssignments { get; set; }
        public virtual ICollection<WorkflowStatus> WorkflowStatuses { get; set; }
    }
}

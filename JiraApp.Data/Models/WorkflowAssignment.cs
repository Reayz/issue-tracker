using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class WorkflowAssignment
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public int TemplateId { get; set; }
        public DateTime AssignDate { get; set; }
        public string AssignBy { get; set; } = null!;

        public virtual Project Project { get; set; } = null!;
        public virtual WorkflowTemplate Template { get; set; } = null!;
    }
}

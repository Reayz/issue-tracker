using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraApp.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            CustomFields = new HashSet<CustomField>();
            Issues = new HashSet<Issue>();
            KeyTrackers = new HashSet<KeyTracker>();
            ProjectAssignments = new HashSet<ProjectAssignment>();
            Sprints = new HashSet<Sprint>();
            WorkflowAssignments = new HashSet<WorkflowAssignment>();
        }

        [Display(Name = "Project ID")]
        public int ProjectId { get; set; }
        [Display(Name = "Tenant ID")]
        public int TenantId { get; set; }
        [Display(Name = "Project Key")]
        public string ProjectKey { get; set; } = null!;
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; } = null!;
        [Display(Name = "Project Type")]
        public string ProjectType { get; set; } = null!;
        [Display(Name = "Project Owner")]
        public string? Owner { get; set; }
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]

        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<CustomField> CustomFields { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<KeyTracker> KeyTrackers { get; set; }
        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
        public virtual ICollection<WorkflowAssignment> WorkflowAssignments { get; set; }
    }
}

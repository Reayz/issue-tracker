using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Attachments = new HashSet<Attachment>();
            CustomFieldValues = new HashSet<CustomFieldValue>();
            IssueComments = new HashSet<IssueComment>();
            IssueHistories = new HashSet<IssueHistory>();
        }

        public int IssueId { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public int? SprintId { get; set; }
        public int? EpicLinkId { get; set; }
        public int? ParentId { get; set; }
        public string IssueNo { get; set; } = null!;
        public string IssueType { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Labels { get; set; }
        public string? Assignee { get; set; }
        public string? Developer { get; set; }
        public string? Qa { get; set; }
        public string? Estimation { get; set; }
        public string? CustomColumn1 { get; set; }
        public string? CustomColumn2 { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }
        public virtual ICollection<IssueComment> IssueComments { get; set; }
        public virtual ICollection<IssueHistory> IssueHistories { get; set; }
    }
}

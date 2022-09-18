using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class IssueComment
    {
        public IssueComment()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int CommentId { get; set; }
        public int TenantId { get; set; }
        public int IssueId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Issue Issue { get; set; } = null!;
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}

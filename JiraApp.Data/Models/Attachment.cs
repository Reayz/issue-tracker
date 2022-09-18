using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int IssueId { get; set; }
        public int? CommentId { get; set; }
        public string AttachmentType { get; set; } = null!;
        public byte[] FileContent { get; set; } = null!;
        public DateTime AttachedDate { get; set; }
        public string AttachedBy { get; set; } = null!;

        public virtual IssueComment? Comment { get; set; }
        public virtual Issue Issue { get; set; } = null!;
    }
}

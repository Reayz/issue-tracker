using System;
using System.Collections.Generic;

namespace JiraApp.Data.Models
{
    public partial class Sprint
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ProjectId { get; set; }
        public string SprintName { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual Project Project { get; set; } = null!;
    }
}

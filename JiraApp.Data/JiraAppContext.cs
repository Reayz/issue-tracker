using System;
using System.Collections.Generic;
using JiraApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JiraApp.Data
{
    public partial class JiraAppContext : DbContext
    {
        public JiraAppContext()
        {
        }

        public JiraAppContext(DbContextOptions<JiraAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllCredentialHistory> AllCredentialHistories { get; set; } = null!;
        public virtual DbSet<AppCredential> AppCredentials { get; set; } = null!;
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<CustomField> CustomFields { get; set; } = null!;
        public virtual DbSet<CustomFieldValue> CustomFieldValues { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<IssueComment> IssueComments { get; set; } = null!;
        public virtual DbSet<IssueHistory> IssueHistories { get; set; } = null!;
        public virtual DbSet<KeyTracker> KeyTrackers { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectAssignment> ProjectAssignments { get; set; } = null!;
        public virtual DbSet<ProjectRole> ProjectRoles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleAssginment> RoleAssginments { get; set; } = null!;
        public virtual DbSet<Sprint> Sprints { get; set; } = null!;
        public virtual DbSet<TenantGroup> TenantGroups { get; set; } = null!;
        public virtual DbSet<WorkflowAssignment> WorkflowAssignments { get; set; } = null!;
        public virtual DbSet<WorkflowStatus> WorkflowStatuses { get; set; } = null!;
        public virtual DbSet<WorkflowTemplate> WorkflowTemplates { get; set; } = null!;
        public virtual DbSet<WorkflowTransition> WorkflowTransitions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllCredentialHistory>(entity =>
            {
                entity.ToTable("AllCredentialHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AllCredentialHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("allcredentialhistory_userid_foreign");
            });

            modelBuilder.Entity<AppCredential>(entity =>
            {
                entity.ToTable("AppCredential");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConnectionKey).HasMaxLength(255);

                entity.Property(e => e.Dbname)
                    .HasMaxLength(255)
                    .HasColumnName("DBName");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.SubdomainName).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppCredentials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("credentials_userid_foreign");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_userid_primary");

                entity.ToTable("AppUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttachedBy).HasMaxLength(255);

                entity.Property(e => e.AttachedDate).HasColumnType("datetime");

                entity.Property(e => e.AttachmentType).HasMaxLength(255);

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("attachment_commentid_foreign");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attachment_issueid_foreign");
            });

            modelBuilder.Entity<CustomField>(entity =>
            {
                entity.ToTable("CustomField");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultValue).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FieldName).HasMaxLength(255);

                entity.Property(e => e.FieldType).HasMaxLength(255);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomFields)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customfield_projectid_foreign");
            });

            modelBuilder.Entity<CustomFieldValue>(entity =>
            {
                entity.ToTable("CustomFieldValue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.FieldValue).HasMaxLength(255);

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.ValueSetBy).HasMaxLength(255);

                entity.Property(e => e.ValueSetDate).HasColumnType("datetime");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.CustomFieldValues)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customfieldvalue_fieldid_foreign");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.CustomFieldValues)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customfieldvalue_issueid_foreign");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.Assignee).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomColumn1).HasMaxLength(255);

                entity.Property(e => e.CustomColumn2).HasMaxLength(255);

                entity.Property(e => e.Developer).HasMaxLength(255);

                entity.Property(e => e.EpicLinkId).HasColumnName("EpicLinkID");

                entity.Property(e => e.Estimation).HasMaxLength(255);

                entity.Property(e => e.IssueNo).HasMaxLength(255);

                entity.Property(e => e.IssueType).HasMaxLength(255);

                entity.Property(e => e.Labels).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Priority).HasMaxLength(255);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Qa)
                    .HasMaxLength(255)
                    .HasColumnName("QA");

                entity.Property(e => e.SprintId).HasColumnName("SprintID");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("issue_projectid_foreign");
            });

            modelBuilder.Entity<IssueComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("issuecomment_id_primary");

                entity.ToTable("IssueComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueComments)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("issuecomment_issueid_foreign");
            });

            modelBuilder.Entity<IssueHistory>(entity =>
            {
                entity.ToTable("IssueHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.NewValue).HasMaxLength(255);

                entity.Property(e => e.OldValue).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedField).HasMaxLength(255);

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueHistories)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("issuehistory_issueid_foreign");
            });

            modelBuilder.Entity<KeyTracker>(entity =>
            {
                entity.ToTable("KeyTracker");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LookupKey).HasMaxLength(255);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.KeyTrackers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KeyTracker_projectid_foreign");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Owner).HasMaxLength(255);

                entity.Property(e => e.ProjectKey).HasMaxLength(255);

                entity.Property(e => e.ProjectName).HasMaxLength(255);

                entity.Property(e => e.ProjectType).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");
            });

            modelBuilder.Entity<ProjectAssignment>(entity =>
            {
                entity.ToTable("ProjectAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssginedBy).HasMaxLength(255);

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectRoleId).HasColumnName("ProjectRoleID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectAssignments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectassignment_projectid_foreign");

                entity.HasOne(d => d.ProjectRole)
                    .WithMany(p => p.ProjectAssignments)
                    .HasForeignKey(d => d.ProjectRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectassignment_projectroleid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectAssignments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectassignment_userid_foreign");
            });

            modelBuilder.Entity<ProjectRole>(entity =>
            {
                entity.ToTable("ProjectRole");

                entity.Property(e => e.ProjectRoleId).HasColumnName("ProjectRoleID");

                entity.Property(e => e.ProjectRoleName).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");
            });

            modelBuilder.Entity<RoleAssginment>(entity =>
            {
                entity.ToTable("RoleAssginment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignedBy).HasMaxLength(255);

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAssginments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleassginment_roleid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleAssginments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleassginment_userid_foreign");
            });

            modelBuilder.Entity<Sprint>(entity =>
            {
                entity.ToTable("Sprint");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.SprintName).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Sprints)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sprint_projectid_foreign");
            });

            modelBuilder.Entity<TenantGroup>(entity =>
            {
                entity.ToTable("TenantGroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientName).HasMaxLength(255);

                entity.Property(e => e.ConnectionKey).HasMaxLength(255);

                entity.Property(e => e.Dbname)
                    .HasMaxLength(255)
                    .HasColumnName("DBName");

                entity.Property(e => e.SubdomainName).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");
            });

            modelBuilder.Entity<WorkflowAssignment>(entity =>
            {
                entity.ToTable("WorkflowAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignBy).HasMaxLength(255);

                entity.Property(e => e.AssignDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkflowAssignments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workflowassignment_projectid_foreign");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.WorkflowAssignments)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workflowassignment_templateid_foreign");
            });

            modelBuilder.Entity<WorkflowStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("workflowstatus_statusid_primary");

                entity.ToTable("WorkflowStatus");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusText).HasMaxLength(255);

                entity.Property(e => e.TemplateId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TemplateID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.WorkflowStatuses)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workflowstatus_templateid_foreign");
            });

            modelBuilder.Entity<WorkflowTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("workflowtemplate_templateid_primary");

                entity.ToTable("WorkflowTemplate");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TemplateName).HasMaxLength(255);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");
            });

            modelBuilder.Entity<WorkflowTransition>(entity =>
            {
                entity.ToTable("WorkflowTransition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusFromId).HasColumnName("StatusFromID");

                entity.Property(e => e.StatusToId).HasColumnName("StatusToID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.StatusFrom)
                    .WithMany(p => p.WorkflowTransitionStatusFroms)
                    .HasForeignKey(d => d.StatusFromId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workflowtransition_statusfromid_foreign");

                entity.HasOne(d => d.StatusTo)
                    .WithMany(p => p.WorkflowTransitionStatusTos)
                    .HasForeignKey(d => d.StatusToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workflowtransition_statustoid_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

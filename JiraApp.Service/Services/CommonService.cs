
using JiraApp.Data.Models;
using JiraApp.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JiraApp.Service.Services
{
    public class CommonService : ICommonService
    {
        private readonly IJiraAppRepository<Project> _projectRepository;
        private readonly IJiraAppRepository<ProjectAssignment> _projectAssignmentRepository;
        private readonly HttpContext _httpContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommonService(IJiraAppRepository<Project> projectRepository,
                            IJiraAppRepository<ProjectAssignment> projectAssignmentRepository,
                            IHttpContextAccessor httpContextAccessor)
        {
            _projectRepository = projectRepository;
            _projectAssignmentRepository = projectAssignmentRepository;
            _httpContextAccessor = httpContextAccessor;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Project GetProjectInfo(int tenantID, int userID)
        {
            int projectID = _projectAssignmentRepository.GetAll().FirstOrDefault(x => x.TenantId == tenantID && x.UserId == userID).ProjectId;

            Project project = _projectRepository.GetAll().FirstOrDefault(x => x.TenantId == tenantID && x.ProjectId == projectID);

            return project;
        }   

        public int GetTenantID()
        {
            ClaimsPrincipal principal = _httpContext.User as ClaimsPrincipal;
            int tenantID = 0;
            if (null != principal)
            {
                string tenantIDStr = principal.Claims.FirstOrDefault(x => x.Type == "TenantId").Value;
                Int32.TryParse(tenantIDStr, out tenantID);
            }
            return tenantID;
        }


        public int GetUserID()
        {
            ClaimsPrincipal principal = _httpContext.User as ClaimsPrincipal;
            int userID = 0;
            if (null != principal)
            {
                string userIDStr = principal.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                Int32.TryParse(userIDStr, out userID);
            }
            return userID;
        }


        public int GetProjectID()
        {
            ClaimsPrincipal principal = _httpContext.User as ClaimsPrincipal;
            int projectId = 0;
            if (null != principal)
            {
                string projectIdStr = principal.Claims.FirstOrDefault(x => x.Type == "ProjectId").Value;
                Int32.TryParse(projectIdStr, out projectId);
            }
            return projectId;
        }

        public string GetUserName()
        {
            ClaimsPrincipal principal = _httpContext.User as ClaimsPrincipal;
            string userName = "";
            if (null != principal)
            {
                userName = principal.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
            }
            return userName;
        }

        public string GetProjectName()
        {
            ClaimsPrincipal principal = _httpContext.User as ClaimsPrincipal;
            string projectName = "";
            if (null != principal)
            {
                projectName = principal.Claims.FirstOrDefault(x => x.Type == "ProjectName").Value;
            }
            return projectName;
        }
    }
}

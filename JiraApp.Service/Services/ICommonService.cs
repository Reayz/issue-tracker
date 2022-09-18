using JiraApp.Data.Models;

namespace JiraApp.Service.Services
{
    public interface ICommonService
    {
        Project GetProjectInfo(int tenantID, int userID);
        int GetTenantID();
        int GetUserID();
        int GetProjectID();
        string GetUserName();
        string GetProjectName();

    }
}

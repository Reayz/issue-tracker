using JiraApp.Data.Models;

namespace JiraApp.Service.Services
{
    public interface IIssueService
    {
        List<Issue> FindAllIssues();
        Issue GetIssueByKey(string issueKey);
        string AddIssue(Issue issue);
        string UpdateIssue(Issue issue);
        string AddComment(int issueId, string commentText);
    }
}

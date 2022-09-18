using JiraApp.Data.Models;
using JiraApp.Repository;

namespace JiraApp.Service.Services
{
    public class IssueService : IIssueService
    {
        private readonly IJiraAppRepository<Issue> _issueRepository;
        private readonly IJiraAppRepository<IssueComment> _commentRepository;
        private readonly IJiraAppRepository<KeyTracker> _keyTrackerRepository;
        private readonly ICommonService _commonService;

        public IssueService(IJiraAppRepository<Issue> issueRepository,
                            IJiraAppRepository<IssueComment> commentRepository,
                            IJiraAppRepository<KeyTracker> keyTrackerRepository,
                            ICommonService commonService)
        {
            _issueRepository = issueRepository;
            _commentRepository = commentRepository;
            _keyTrackerRepository = keyTrackerRepository;
            _commonService = commonService;

        }

        public List<Issue> FindAllIssues()
        {

            // For issue with tenentID and ProjectID, Filter data in service layer
            // Demerit of generic repository
            // can pass pradicate into repositoy 

            int tenantID = _commonService.GetTenantID();

            List<Issue> issues = _issueRepository.GetAll().ToList();
            var y = issues.Where(x => x.TenantId == tenantID);
            List<Issue> results = issues.FindAll(x => x.TenantId == tenantID);
            return results;
        }

        public Issue GetIssueByKey(string issueKey)
        {
            int tenantID = _commonService.GetTenantID();

            List<Issue> issues = _issueRepository.GetAll().ToList();
            Issue results = issues.FirstOrDefault(x => x.TenantId == tenantID && x.IssueNo == issueKey);

            List<IssueComment> comments = _commentRepository.GetAll().ToList();
            results.IssueComments = comments.FindAll(x => x.TenantId == tenantID && x.IssueId == results.IssueId).OrderByDescending(x => x.CreatedDate).ToArray();
            return results;
        }

        public string AddIssue(Issue issue)
        {
            int tenantID = _commonService.GetTenantID();
            int userID = _commonService.GetUserID();
            int projectID = _commonService.GetProjectID();

            Project project = _commonService.GetProjectInfo(tenantID, userID);

            List<KeyTracker> trackers = _keyTrackerRepository.GetAll().ToList();
            KeyTracker results = trackers.FirstOrDefault(x => x.TenantId == tenantID && x.ProjectId == projectID && x.LookupKey == "IssueKey");
            string issueKey = project.ProjectKey + "-" + results.NextKey;

            issue.TenantId = tenantID;
            issue.ProjectId = projectID;
            issue.IssueNo = issueKey;
            issue.Status = "Backlog";
            issue.CreatedBy = _commonService.GetUserName();
            issue.CreatedDate = DateTime.Now;

            _issueRepository.Insert(issue);
            _issueRepository.Save();


            results.NextKey++;
            _keyTrackerRepository.Update(results);
            _keyTrackerRepository.Save();

            return issueKey;
        }

        public string UpdateIssue(Issue issue)
        {
            int tenantID = _commonService.GetTenantID();
            List<Issue> issues = _issueRepository.GetAll().ToList();
            Issue results = issues.FirstOrDefault(x => x.TenantId == tenantID && x.IssueId == issue.IssueId);

            results.IssueType = issue.IssueType;
            results.Title = issue.Title;
            results.Description = issue.Description;
            results.Priority = issue.Priority;
            results.ModifiedBy = _commonService.GetUserName();
            results.ModifiedDate = DateTime.Now;

            _issueRepository.Update(results);
            _issueRepository.Save();

            return results.IssueNo;
        }

        public string AddComment(int issueId, string commentText)
        {
            int tenantID = _commonService.GetTenantID();
            List<Issue> issues = _issueRepository.GetAll().ToList();
            Issue results = issues.FirstOrDefault(x => x.TenantId == tenantID && x.IssueId == issueId);

            IssueComment comment = new IssueComment();
            comment.TenantId = tenantID;
            comment.IssueId = issueId;
            comment.CommentText = commentText;
            comment.CreatedBy = _commonService.GetUserName();
            comment.CreatedDate = DateTime.Now;

            _commentRepository.Insert(comment);
            _commentRepository.Save();

            return results.IssueNo;
        }
    }
}

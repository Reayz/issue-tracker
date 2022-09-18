using JiraApp.Data;
using JiraApp.Data.Models;
using JiraApp.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JiraApp.Web.Controllers
{
    [Authorize]
    public class IssueController : Controller
    {
        private readonly HttpContext _httpContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JiraAppContext _context;
        private readonly IIssueService _issueService;
        private readonly ICommonService _commonService;

        public IssueController(IHttpContextAccessor httpContextAccessor,
                                JiraAppContext context,
                                IIssueService issueService,
                                ICommonService commonService)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _issueService = issueService;
            _commonService = commonService;
        }

        private void Initialize()
        {
            ViewData["ProjectName"] = _commonService.GetProjectName();
            ViewData["UserName"] = _commonService.GetUserName();
        }

        public IActionResult Dashboard()
        {
            Initialize();
            List<Issue> issues = _issueService.FindAllIssues();
            return View(issues);
        }

        public IActionResult OpenIssue(string issueKey = "")
        {
            Initialize();
            if (string.IsNullOrEmpty(issueKey))
            {
                issueKey = "";
            }

            Issue issue = _issueService.GetIssueByKey(issueKey);
            return View(issue);
        }

        public ActionResult CreateIssue(Issue givenIssue)
        {
            Initialize();
            return PartialView("CreateIssue", givenIssue);
        }

        public ActionResult SaveIssue([FromBody] Issue givenIssue)
        {
            Initialize();
            try
            {
                string issueKey = string.Empty;
                if (givenIssue.IssueId > 0)
                {
                    issueKey = _issueService.UpdateIssue(givenIssue);
                }
                else
                {
                    issueKey = _issueService.AddIssue(givenIssue);
                }
                return Json(issueKey);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult VerifyIssueNumber([FromBody] Issue givenIssue)
        {
            Initialize();
            Issue issue = _issueService.GetIssueByKey(givenIssue.IssueNo);
            if (issue != null)
            {
                return Json(issue.IssueNo);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult LoadComments(string issueKey)
        {
            Initialize();
            return PartialView("Comments", _issueService.GetIssueByKey(issueKey));
        }

        private IssueComment GetIssueComments(int issueID)
        {
            Initialize();
            IssueComment comments = new IssueComment();
            return comments;
        }

        public ActionResult AddComment([FromBody] Issue issue)
        {
            Initialize();
            try
            {
                string issueKey = _issueService.AddComment(issue.IssueId, issue.CustomColumn1);
                return LoadComments(issueKey);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        public ActionResult GetIssueDetails([FromBody] Issue givenIssue)
        {
            Initialize();
            try
            {
                Issue issue = _issueService.GetIssueByKey(givenIssue.IssueNo);
                return CreateIssue(issue);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
    }
}

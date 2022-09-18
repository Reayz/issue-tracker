using JiraApp.Data.Models;
using JiraApp.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JiraApp.Web.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ICommonService _commonService;
        private readonly IProjectService _projectService;

        public ProjectsController(ICommonService commonService,
                                  IProjectService projectService)
        {
            _commonService = commonService;
            _projectService = projectService;
        }

        private void Initialize()
        {
            ViewData["ProjectName"] = _commonService.GetProjectName();
            ViewData["UserName"] = _commonService.GetUserName();
        }

        public async Task<IActionResult> Index()
        {
            Initialize();

            List<Project> projects = _projectService.FindAllProjects();
            return View(projects);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Initialize();
            if (id == null)
            {
                return NotFound();
            }

            Project project = _projectService.GetProjectById(id.Value);
            return View(project);
        }

        public IActionResult Create()
        {
            Initialize();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,TenantId,ProjectKey,ProjectName,ProjectType,Owner,CreatedDate,CreatedBy")] Project project)
        {
            Initialize();
            _projectService.AddProject(project);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Initialize();
            if (id == null)
            {
                return NotFound();
            }

            Project project = _projectService.GetProjectById(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,TenantId,ProjectKey,ProjectName,ProjectType,Owner,CreatedDate,CreatedBy")] Project project)
        {
            Initialize();
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _projectService.UpdateProject(project);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Initialize();
            if (id == null)
            {
                return NotFound();
            }

            Project project = _projectService.GetProjectById(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Initialize();
            Project project = _projectService.GetProjectById(id);
            if (project != null)
            {
                _projectService.DeleteProject(project);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

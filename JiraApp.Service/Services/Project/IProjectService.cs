using JiraApp.Data.Models;

namespace JiraApp.Service.Services
{
    public interface IProjectService
    {
        List<Project> FindAllProjects();
        Project GetProjectById(int id);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}

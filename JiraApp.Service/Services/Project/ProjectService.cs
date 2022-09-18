using JiraApp.Data.Models;
using JiraApp.Repository;

namespace JiraApp.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IJiraAppRepository<Project> _repository;
        private readonly ICommonService _commonService;

        public ProjectService(IJiraAppRepository<Project> repository,
                                ICommonService commonService)
        {
            _repository = repository;
            _commonService = commonService;

        }

        public List<Project> FindAllProjects()
        {
            int tenantID = _commonService.GetTenantID();

            List<Project> projects = _repository.GetAll().ToList();
            List<Project> results = projects.FindAll(x => x.TenantId == tenantID);
            return results;

            //generic Get function with a predicate
            //public IQueryable<T> Get(Expression<Func<T, bool>> predicate)   // should write in repository
            //{
            //    return context.Set<T>().Where(predicate);
            //}
            //var itemsWithSomeFlagSet = _repository.Get(i => i.SomeFlag);    // should write in service 
        }

        public Project GetProjectById(int id)
        {
            Project project = _repository.GetById(id);
            return project;
        }

        void IProjectService.AddProject(Project project)
        {
            project.TenantId = _commonService.GetTenantID();
            project.CreatedBy = _commonService.GetUserName();
            project.CreatedDate = DateTime.Now;

            _repository.Insert(project);
            _repository.Save();
            return;
        }

        void IProjectService.DeleteProject(Project project)
        {
            _repository.Delete(project);
            _repository.Save();
            return;
        }

        void IProjectService.UpdateProject(Project project)
        {
            _repository.Update(project);
            _repository.Save();
            return;
        }
    }
}

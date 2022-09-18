using JiraApp.Data.Models;
using JiraApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApp.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IJiraAppRepository<AppCredential> _repository;
        public LoginService(IJiraAppRepository<AppCredential> repository)
        {
            _repository = repository;
        }

        public AppCredential VerifyUser(AppCredential userData)
        {
            List<AppCredential> credentials = _repository.GetAll().ToList();
            AppCredential credential =  credentials.Find(x => x.UserName == userData.UserName && x.Password == userData.Password);
            if (credential != null)
            {
                return credential;
            }
            return new AppCredential();
        }
    }
}

using JiraApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApp.Service.Services
{
    public interface ILoginService
    {
        AppCredential VerifyUser(AppCredential userData);
    }
}

using JiraApp.Data.Models;
using JiraApp.Service.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JiraApp.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoginService _loginService;
        private readonly ICommonService _commonService;

        public LoginController(IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor,
                                ILoginService loginService,
                                ICommonService commonService)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = httpContextAccessor.HttpContext;
            _configuration = configuration;
            _loginService = loginService;
            _commonService = commonService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            _httpContext.Session.SetString("IsAuthenticated", "");
            _httpContext.Session.SetString("CurrentUserName", "");
            _httpContext.Session.SetInt32("CurrentUserID", 0);
            _httpContext.Session.SetInt32("CurrentTenantID", 0);
            _httpContext.Session.SetInt32("CurrentUserProjectID", 0);

            await _httpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public async Task<ActionResult> VerifyUser([FromBody] AppCredential userData)
        {

            AppCredential model = _loginService.VerifyUser(userData);

            if (model.UserId > 0)
            {
                Project project = _commonService.GetProjectInfo(model.TenantId, model.UserId);

                var claims = new List<Claim>
                {
                    new Claim("UserName", model.UserName),
                    new Claim("UserId", model.UserId.ToString()),
                    new Claim("TenantId", model.TenantId.ToString()),
                    new Claim("ProjectId", project.ProjectId.ToString()),
                    new Claim("ProjectName", project.ProjectName),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };

                await _httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}

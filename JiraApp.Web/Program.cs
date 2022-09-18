using JiraApp.Data;
using JiraApp.Data.Models;
using JiraApp.Repository;
using JiraApp.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Login/Unauthorized/";
        options.LoginPath = "/Login/Unauthorized/";
    });


builder.Services.AddScoped<IJiraAppRepository<Issue>, JiraAppRepository<Issue>>();
builder.Services.AddScoped<IJiraAppRepository<IssueComment>, JiraAppRepository<IssueComment>>();
builder.Services.AddScoped<IJiraAppRepository<AppCredential>, JiraAppRepository<AppCredential>>();
builder.Services.AddScoped<IJiraAppRepository<Project>, JiraAppRepository<Project>>();
builder.Services.AddScoped<IJiraAppRepository<ProjectAssignment>, JiraAppRepository<ProjectAssignment>>();
builder.Services.AddScoped<IJiraAppRepository<KeyTracker>, JiraAppRepository<KeyTracker>>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICommonService, CommonService>();

builder.Services.AddDbContext<JiraAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Key1")));
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

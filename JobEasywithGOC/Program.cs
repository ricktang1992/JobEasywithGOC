using JobEasyWithGOC.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GoC.WebTemplate.Components.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using JobEasyWithGOC.Data.Interfaces;
using GoC.WebTemplate.CoreMVC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var services = builder.Services;

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Home/Index";
                options.LogoutPath = "/Home/LogOut";
            });
services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    //options.CheckConsentNeeded = context => true;
    //options.MinimumSameSitePolicy = SameSiteMode.None;
    var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
    {
        Path = "/",
        HttpOnly = false,
        IsEssential = true,
        Expires = DateTime.Now.AddMonths(1),
    };
});
services.AddDistributedMemoryCache();
services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.Name = ".GoCWebTemplate.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//services.AddSingleton(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddScoped<IJobPostRepository, JobPostRepository>();
services.AddScoped<IApplicantRepository, ApplicantRepository>();
services.AddScoped<IApplicationRepository, ApplicationRepository>();
services.AddScoped<ICompanyRepository, CompanyRepository>();

//services.AddScoped<ICaseTypeRepository, CaseTypeRepository>();
//services.AddScoped<IUserRepository, UserRepository>();
//services.AddScoped<IQuestionRepository, QuestionRepository>();
//services.AddScoped<IAnnotationRepository, AnnotationRepository>();

#region snippet1
services.AddLocalization(options => options.ResourcesPath = "Resources");

services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-CA"),
                        new CultureInfo("fr-CA")
                    };

    options.DefaultRequestCulture = new RequestCulture("en-CA");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
#endregion


services.AddControllersWithViews();
services.AddAutoMapper(typeof(Program));

//services.Configure<Dynamics>(Configuration.GetSection("Dynamics"));
//services.Configure<HrApi>(Configuration.GetSection("HrApi"));

services.AddModelAccessor();
services.ConfigureGoCTemplateRequestLocalization(); // >= v2.1.1






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

app.UseCookiePolicy();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



#region snippet2
var supportedCultures = new[]
{
                new CultureInfo("en-CA"),
                new CultureInfo("fr-CA"),
            };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-CA"),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});

app.UseStaticFiles();
#endregion

app.UseRequestLocalization(); // >= v2.1.1


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

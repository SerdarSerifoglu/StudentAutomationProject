using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using StudentAutomationProject.BLL.Abstract;
using StudentAutomationProject.BLL.Concrete;
using StudentAutomationProject.DAL.Abstract;
using StudentAutomationProject.DAL.Concrete;
using StudentAutomationProject.Identity;

namespace StudentAutomationProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<SapIdentityDbContext>(options => options.UseSqlServer(Configuration["dbConnection"]));
            services.AddDbContext<SapIdentityDbContext>(options => options.UseSqlServer("Server=DESKTOP-RHAN2O7;Database=StudentAutoDB;User ID=serdar2;Password=123456;"));
            

            services.AddIdentity<SapIdentityUser, SapIdentityRole>()
               .AddEntityFrameworkStores<SapIdentityDbContext>()
               .AddDefaultTokenProviders();

            //Sayfalarda bu �ekilde d�n��t�r�len jsonlar�n property isimlerinin camel case ile yaz�lmas�n� engelledi.
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //DependencyInjection
            services.AddScoped<IDepartmentsService, DepartmentsManager>();
            services.AddScoped<IDepartmentsDAL, EfDepartmentsDAL>();
            services.AddScoped<ICoursesService, CoursesManager>();
            services.AddScoped<ICoursesDAL, EfCoursesDAL>();
            services.AddScoped<IStudentsService, StudentsManager>();
            services.AddScoped<IStudentsDAL, EfStudentsDAL>();
            services.AddScoped<IPersonsService, PersonsManager>();
            services.AddScoped<IPersonsDAL, EfPersonsDAL>();
            services.AddScoped<IDepartmentPersonsService, DepartmentPersonsManager>();
            services.AddScoped<IDepartmentPersonsDAL, EfDepartmentPersonsDAL>();
            services.AddScoped<IExamsService, ExamsManager>();
            services.AddScoped<IExamsDAL, EfExamsDAL>();
            services.AddScoped<ICourseRegistrationService, CourseRegistrationManager>();
            services.AddScoped<ICourseRegistrationDAL, EfCourseRegistrationDAL>();
            services.AddScoped<ITeachersService, TeachersManager>();
            services.AddScoped<ITeachersDAL, EfTeachersDAL>();
            services.AddScoped<IStudentAffairsService, StudentAffairsManager>();
            services.AddScoped<IStudentAffairsDAL, EfStudentAffairsDAL>();
            services.AddScoped<IExamResultsService, ExamResultsManager>();
            services.AddScoped<IExamResultsDAL, EfExamResultsDAL>();



            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                //Bir�ok kez denedi�inde kilitlensin
                options.Lockout.MaxFailedAccessAttempts = 5;
                //kilitlenen bu kadar dk sonra a��ls�n
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //yeni kullan�c�lar i�in ge�erli olsun mu
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                //�rn. cookie s�resi 10 dk ise 6.dk da girildi�inde s�reyi yeniler
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name=".StudentAutomation.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Department}/{action=Index}/{id?}");
            });
        }
    }
}

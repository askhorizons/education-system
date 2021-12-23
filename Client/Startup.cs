using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Profiles;
using Domain;
using Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

namespace Client
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IConfiguration Configuration { get; set; }

        // DI Container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DataContext>();

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";

                options.Cookie.Name = "AppCookie_Ask";
                options.Cookie.HttpOnly = true;
                
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredUniqueChars = 0;

                option.User.RequireUniqueEmail = true;

                // Default Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;
            });

            services.AddTransient<DataSeeder>();

            services.AddAutoMapper(option =>
            {
                option.AddProfile(new CandidateProfile());
            });

            services.AddTransient<IEmailSender, EmailSender>();
        }

        // Middleware
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });

            });
        }
    }
}

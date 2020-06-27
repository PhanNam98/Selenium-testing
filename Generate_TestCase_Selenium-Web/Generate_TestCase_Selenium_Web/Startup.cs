using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Generate_TestCase_Selenium_Web.Models;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Quartz.Spi;
using Generate_TestCase_Selenium_Web.Factories;
using Quartz;
using Quartz.Impl;
using Coravel;
using Generate_TestCase_Selenium_Web.Jobs;
using Generate_TestCase_Selenium_Web.Services;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;

namespace Generate_TestCase_Selenium_Web
{
    public class Startup
    {
        private IScheduler _quartzScheduler;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _quartzScheduler = ConfigureQuartz();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ElementDBContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
            });
            services.AddSingleton(provider => _quartzScheduler);
            services.AddTransient<RunTestcaseJob>();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                //(options=> options.Stores.MaxLengthForKeys=128)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
            .AddGoogle(options =>
            {
               IConfigurationSection googleAuthNSection =
               Configuration.GetSection("Authentication:Google");

                options.ClientId = "880817271081-p0eldkcvuajmt6cfrejdl7kjf3asm5mm.apps.googleusercontent.com";
                options.ClientSecret = "COW_bCXJVYpjhNpVmpXh6slA";
             });


            services.AddSession(options =>
            {
                // Set session timeout value
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSignalR();
            services.AddQueue();
            // Add our job
            //services.AddSingleton<HelloWorldJob>();
            services.AddSingleton<StartJobSchedule>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(StartJobSchedule),
                //cronExpression: "0/5 * * * * ?")); // run every 5 seconds
                cronExpression: "")); // run after web start
            services.AddHostedService<QuartzHostedService>();

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Login");

        }
        private void OnShutdown()
        {
            //shutdown quartz is not shutdown already
            if (!_quartzScheduler.IsShutdown) _quartzScheduler.Shutdown();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            _quartzScheduler.JobFactory = new SingletonJobFactory(app.ApplicationServices);
            _quartzScheduler.Start().Wait();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<JobProgressHub>("/jobProgress");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
       name: "MyArea",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
            //app.Use(async (context, next) =>
            //{
            //    var url = context.Request.Path.Value;

            //    // Redirect to an external URL
            //    if (url.Contains("/Identity/Account/Login"))
            //    {
            //        context.Request.Path = "/Login";
            //        return;   // short circuit
            //    }

            //    await next();
            //});
        }
        public IScheduler ConfigureQuartz()
        {
            NameValueCollection props = new NameValueCollection
             {
              { "quartz.serializer.type", "binary" },
              //{ "quartz.serializer.type", "json" },
              // { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
              //   { "quartz.jobStore.dataSource", "default" },
              //   { "quartz.dataSource.default.provider", "SqlServer" },
              //    { "quartz.dataSource.default.connectionString", "Server=.;Integrated Security=true;Initial Catalog = Quartz" },
              //    {"quartz.jobStore.clustered","true" },
              //    { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz" }
              };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = factory.GetScheduler().Result;

            return scheduler;
        }
    }
}

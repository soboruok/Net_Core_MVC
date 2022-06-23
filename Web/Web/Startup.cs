using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Web.Data;
using Web.Data.Repositories;
using Web.Models;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAppContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("MyAppConnection"));
            });

            //Membership system can be easily built through Identity.
            services.AddIdentity<ApplicationUser, IdentityRole>()
            //Where will the user data come from?
            .AddEntityFrameworkStores<MyAppContext>()
            //Token for varified user
            .AddDefaultTokenProviders();

            //AddTransient: Create only when needed
            services.AddTransient<DbSeeder>();


            //AddSingleton: Like a static, an instance is created only once during the application cycle
            //AddScoped :ITeacherRepository Instantiate where you need it.
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddMvc();
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication(); //related Login
            app.UseAuthorization(); //related Authorise

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });

            //Wait until the Task type is finished. 
            //seeder.SeedDatabase().Wait(); 
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.System.Data;
using School.System.Repository;
using School.System.Services;

namespace School.System
{
    public class Program
    {
        public static void Main(string[] args)
        {
              
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
          

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        
        public static void DependenciesConfig(IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<IStudentRepository, StudentRepository>();
            #endregion Repositories

            #region Services
            services.AddTransient<IStudentServices, StudentServices>();
            #endregion Services
        }
    }
}
using Company.Data.Contexts;
using Company.Reposatry.Interfaces;
using Company.Reposatry.Reposatries;
using Company.Services;
using Company.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace ProjectMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
           //builder.Services.AddScoped<IEmployeeReposatry, EmployeeReposatry>();
           //builder.Services.AddScoped<IDepartmentreposatry, DepartmentReposatry>();
           builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
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
    }
}

using Company.Data.Contexts;
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Reposatry.Reposatries;
using Company.Services;
using Company.Services.Mapping;
using Company.Services.Services;
using Microsoft.AspNetCore.Identity;
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


            builder.Services.AddAutoMapper(X => X.AddProfile(new EmployeeProfile()));
            //builder.Services.AddAutoMapper(X => X.AddProfile(new DepartmentProfile()));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Config =>
            {
                Config.Password.RequiredUniqueChars = 2;
                Config.Password.RequireDigit = true;
                Config.Password.RequireLowercase = true;
                Config.Password.RequireUppercase = true;
                Config.Password.RequireNonAlphanumeric = true;
                Config.Password.RequiredLength = 6;
                Config.User.RequireUniqueEmail = true;
                Config.Lockout.AllowedForNewUsers = true;
                Config.Lockout.MaxFailedAccessAttempts = 3;
                Config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);

                
            }).AddEntityFrameworkStores<CompanyDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(Option =>
            {
                Option.Cookie.HttpOnly = true;
                Option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                Option.SlidingExpiration = true;
                Option.LoginPath = "/Account/Login";
                Option.LogoutPath = "/Account/LogOut";
                Option.AccessDeniedPath = "/Account/AccessDenid";
                Option.Cookie.Name = "Hema Cookies";
                Option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                Option.Cookie.SameSite=SameSiteMode.Strict;
            });
            
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
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

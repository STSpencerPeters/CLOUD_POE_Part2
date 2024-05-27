using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CLOUD_POE_Part2.Data;
using System;
using Microsoft.AspNetCore.Identity;
namespace CLOUD_POE_Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the database context
            builder.Services.AddDbContext<SystemDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")
                    ?? throw new InvalidOperationException("Connection string 'SystemDbContext' not found.")));

            // Configure identity services with roles
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SystemDbContext>()
                .AddDefaultTokenProviders();

            // Add services to the container
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Initialize roles and seed default admin user
            using (var serviceScope = app.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                RoleInitializer.InitializeAsync(roleManager, userManager).Wait();
            }

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }



}

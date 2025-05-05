using BLL.Models;
using Data;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Shopegy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ShopegyAppContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUnitofWork, UnitofWork>();

			//register the identityuser 
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
				options =>
				{
					options.Password.RequireNonAlphanumeric = false; 
					options.Password.RequireUppercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireDigit = false;
				}
				).AddEntityFrameworkStores<ShopegyAppContext>().AddDefaultTokenProviders();


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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

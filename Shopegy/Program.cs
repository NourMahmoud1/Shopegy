using BLL.Models;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shopegy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //nour
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ShopegyAppContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



			//register the identityuser 
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
				options =>
				{
					options.Password.RequireNonAlphanumeric = false;  // for easier testing  <= Omar : thanks Saeed :D
					options.Password.RequireUppercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireDigit = false;

					/**/                   // options.SignIn.RequireConfirmedAccount = true;        // saeed 
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

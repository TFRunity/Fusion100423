using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Fusion.DataBase;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.DatabaseMethods;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace Fusion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityDBContext>(opts =>
            {
                opts.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]);
            }).AddIdentity<User, UserRole>()
              .AddEntityFrameworkStores<IdentityDBContext>()
              .AddDefaultTokenProviders();
            services.AddScoped<IdentityDbContext<User, UserRole, Guid>, IdentityDBContext>();
            services.AddTransient<IRepository<UsersPicture>, DBModeratorMethods<UsersPicture>>();
            services.AddTransient<IUserMethods, UsersMethods>();
            services.AddTransient<IUserRepository<User>, DBUserMethods<User>>();
            services.AddTransient<IProductMethods<Product>, ProductMethods<Product>>();
            services.AddTransient<ICategoryMethods<Category>, CategoryMethods<Category>>();
            services.AddTransient<IProductCategoryMethods<ProductCategory>, ProductCategoryMethods<ProductCategory>>();
            services.AddTransient<IOrderRepository<Order>, OrderMethods<Order>>();
            services.ConfigureApplicationCookie(config =>
                {
                    config.LoginPath = "/Account/Login";
                    config.AccessDeniedPath = "/Home/AccessDenied";
                });
            services.AddAuthorization(options =>
                {
                    options.AddPolicy("Admin", builder =>
                    {
                        builder.RequireClaim(ClaimTypes.Role, "Admin");
                    });
                    options.AddPolicy("Manager", builder =>
                    {
                        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Admin")
                                                   || x.User.HasClaim(ClaimTypes.Role, "Manager"));
                    });
                    options.AddPolicy("Member", builder =>
                    {
                        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Member")
                                                   || x.User.HasClaim(ClaimTypes.Role, "Manager")
                                                   || x.User.HasClaim(ClaimTypes.Role, "Admin"));
                    });
                });
            
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+!-";
                options.User.RequireUniqueEmail = false;
            });
            services.AddRouting();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                //endpoints.MapControllerRoute(  
                //    name: "Moderator",      
                //    pattern: "{controller=Moderator}/{action=List}/{FirstSiteModel?}");
                endpoints.MapRazorPages();
            });
            //Убрать на релизе
            CreateRoles(serviceProvider).Wait();
            MakeMockSeed(serviceProvider).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            using (serviceProvider.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();
                string[] roleNames = { "Admin", "Manager", "Member", "Anon" };
                IdentityResult roleResult;
                foreach (var Name in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(Name);
                    if (!roleExist)
                    {
                        roleResult = await roleManager.CreateAsync(new UserRole(Name));
                    }
                }
                var poweruser = new User
                {
                    UserName = "Alexey",
                    Email = "Alex200346babanov@gmail.com",
                    FutureJob = "ABOBUS"
                };
                string userPWD = "310185LexaTFRunity";
                var _user = await userManager.FindByEmailAsync("Alex200346babanov@gmail.com");
                if (_user == null)
                {
                    var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
                    if (createPowerUser.Succeeded)
                    {
                        await userManager.AddClaimAsync(poweruser, new Claim(ClaimTypes.Role, "Admin"));

                    }
                }
            }
        }
        private async Task MakeMockSeed(IServiceProvider serviceProvider)
        {
            using (serviceProvider.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();
                var _user = await userManager.FindByEmailAsync("adex@gmail.com");
                if (_user == null)
                {
                    string pwd = "1TFRunity";
                    User user1 = new User { UserName = "Aboba1", Email = "adex@gmail.com", FutureJob = "aboba" };
                    User user2 = new User { UserName = "Aboba2", Email = "acex@gmail.com", FutureJob = "aboba" };
                    User user3 = new User { UserName = "Aboba3", Email = "awex@gmail.com", FutureJob = "aboba" };
                    List<User> users = new List<User>();
                    users.Add(user1);
                    users.Add(user2);
                    users.Add(user3);
                    foreach (User user in users)
                    {
                        await userManager.CreateAsync(user, pwd);
                    }
                }
            }
        }
    }
    //P.S. Не ставил миграции, т.к. не имеет смысла(проект слишком маленький и нерасширяемый на большие масштабы)
}
//Весь оставшийся Бекэнд
//TO DO: 
//      1)Изменение через продукт
//      2)Добавление продуктов в корзину, (если не аутентифицирован, то кидать на страничку login)
//      2)=>3)Изменение внешнего дизайна и общего состояния вьюхи
//      2)=>4)Просмотр заказов через отдельную страницу + личную страницу ( историю заказов )
//      Tooltip Передавать айди ордера через ViewBag
/////////////////////////////////////////////////////Сделать 2 свойство категории, чтобы адекватно прописывались названия
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Digitalisation_Funding.Interfaces;
using Digitalisation_Funding.Models;
using Digitalisation_Funding.Models.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Digitalisation_Funding.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
          IConfiguration config)
        {
            //iFrame Fix
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://digitalisation-funding.powerappsportals.com/")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials());
            });

            //Context Identity
            // services.AddDbContext<AppIdentityDbContext>(opt =>
            // {
            //     opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            //     //opt.UseSqlServer(config.GetConnectionString("Prod"));
            // });

            //Identity Service
            // services.AddIdentity<User, IdentityRole>(opt =>
            // {
            //     //Username Options
            //     opt.User.RequireUniqueEmail = true;

            //     //Password Options
            //     opt.Password.RequiredLength = 6;
            //     opt.Password.RequireNonAlphanumeric = false;
            //     opt.Password.RequireLowercase = false;
            //     opt.Password.RequireUppercase = false;
            //     opt.Password.RequireDigit = false;

            // }).AddEntityFrameworkStores<AppIdentityDbContext>()
            // .AddDefaultTokenProviders();


            // services.AddDbContext<AppDbContext>(opt =>
            // {
            //     opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            //     //opt.UseSqlServer(config.GetConnectionString("Prod"));
            // });

            //MVC - Route Config
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //Configure Antiforgery options(i - Frame Spooky Repeller);
            services.AddAntiforgery(options =>
            {
                options.SuppressXFrameOptionsHeader = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            //Application Service Registration
            // services.AddTransient<IGoal, EFGoal>();
            // services.AddTransient<IObjective, EFObjective>();
            // services.AddTransient<IKPI, EFKPI>();
            // services.AddTransient<IActivity, EFActivity>();
            // services.AddTransient<IMeasure, EFMeasure>();
            // services.AddTransient<IAction, EFAction>();
            // services.AddTransient<IInstActivity, EFInstActivity>();
            // services.AddTransient<IQActivity, EFQActivity>();
            // services.AddTransient<IAccount, EFAccount>();
            // services.AddTransient<IFaculty, EFFaculty>();

            return services;
        }
    }
}
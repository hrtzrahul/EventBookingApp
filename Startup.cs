using AutoMapper;
using BookEventApp.ConfigurationSettings;
using BookEventApp.Data;
using BookEventApp.Interfaces;
using BookEventApp.IRepository;
using BookEventApp.IRepository.Base;
using BookEventApp.Repository;
using BookEventApp.Repository.Base;
using BookEventApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureBookReadingEventServices(services);
            services.AddControllersWithViews();
        }
        public void ConfigureBookReadingEventServices(IServiceCollection services)
        {
            //Core Layer DI
            services.Configure<Configuration>(Configuration);

            //Infrastructure Layer DI
            ConfigureDatabases(services);
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EventContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            //Application Layer DI
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICommentService, CommentService>();


            //Web Layer DI
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IEventPageService, EventPageService>();
            services.AddScoped<IAccountPageService, AccountPageService>();
            services.AddScoped<ICommentPageService, CommentPageService>();

            //Miscellaneous
#if DEBUG
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            //// use database
            //services.AddDbContext<EventContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("EventDatabase")));
            services.AddDbContext<EventContext>(
                options => options.UseSqlServer("Server=.;Database=EventDatabase;Integrated Security=True;")
                );
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

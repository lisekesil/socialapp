using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using socialapp.Data;
using socialapp.Models;
using socialapp.Repositories;

namespace socialapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SocialApp:Connection"]));
            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IPostRepository, EFPostRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<ICommentRepository, EFCommentRepository>();

            services.AddMvc()
      .AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy => policy.RequireRole(Roles.Admin.ToString()));
                options.AddPolicy("UsersAccess", policy => policy.RequireRole(Roles.User.ToString()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Post}/{action=Index}/{id?}");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sushi.Data;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using Sushi.Data.Repisitory;
using Sushi.Data.Repository;
using Sushi.Middleware;
using System.Net;

namespace Sushi
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<appDBContent>(options => options.UseNpgsql(_confString.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(_confString.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            services.AddHttpContextAccessor();
            services.AddScoped<UserManager<User>>();
            services.AddTransient<IFood, FoodRepository>();
            services.AddTransient<IAllCategory, CategoryRepository>();
            services.AddTransient<IOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp =>
            {
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                var userManager = sp.GetRequiredService<UserManager<User>>();
                var context = sp.GetRequiredService<appDBContent>();

                return ShopCart.GetCart(sp);
            });
            //services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Offert}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "{controller=Home}/{action=List}/{category?}", defaults: new { controller = "Home", action = "List" });
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                appDBContent content = scope.ServiceProvider.GetRequiredService<appDBContent>();
                DbObjects.Initial(content);
            }
        }
    }
}

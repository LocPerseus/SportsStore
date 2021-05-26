using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.DAL;
using SportsStore.Models;
using SportsStore.Repositories;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SportStoreProducts"))
            );
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
                This extension method adds a simple message to HTTP responses that 
                would not otherwise have a body, such as 404 - Not Found responses. 
             */
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(enpoins =>
            {
                enpoins.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Product}/{action=List}/{id?}"
                    );
            });

            SeedData.EnsurePopulated(app);
        }
    }
}

using LittlePacktBookStore.Data;
using LittlePacktBookStore.Models;
using LittlePacktBookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookStore
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Foll. code used to disable enpoints routing in Configure
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddDbContext<LittlePacktBookStoreDbContext>(dbContextOptionBuilder => 
            //dbContextOptionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LittlePackt;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //services.AddSingleton<IRepository<Book>, MockBooksRepository>();
            //services.AddSingleton<IRepository<Carousel>, MockCarouselRepository>();

            services.AddDbContext<LittlePacktBookStoreDbContext>(dbContextOptionBuilder =>
            dbContextOptionBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository<Book>, SqlBooksRepository>();
            services.AddScoped<IRepository<Carousel>, SqlCarouselRespository>();
            services.AddScoped<IRepository<Order>, SqlOrderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMvc(ConfigureRoutes);
            app.UseStaticFiles();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

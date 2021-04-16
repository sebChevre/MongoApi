using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoApi.Models;
using MongoApi.Services;
using Prometheus;

namespace MongoApi
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

            services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });
            
            services.AddSingleton<BeerService>();
            services.AddSingleton<MongoDbService>();

            services.AddControllersWithViews();

            // requires using Microsoft.Extensions.Options
            services.Configure<BeerstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BeerstoreDatabaseSettings)));

            services.AddSingleton<IBeerstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BeerstoreDatabaseSettings>>().Value);

           // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureSwagger(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }
            
            app.UseStaticFiles();

            // Use the Prometheus middleware
            app.UseMetricServer();
            app.UseHttpMetrics();

            ConfigurePrometheus(app);
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }

        private static void ConfigureSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        private static void ConfigurePrometheus(IApplicationBuilder app)
        {
            var counter = Metrics.CreateCounter("pipedream_api_count", "Counts requests to the Pipedream API endpoints", new CounterConfiguration{
            LabelNames = new[] { "method", "endpoint" }
            });
            
            app.Use((context, next) =>{
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });
        }
    }
}

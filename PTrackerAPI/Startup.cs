using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PTrackerAPI.Models;
using PTrackerAPI.Repository;

namespace PTrackerAPI
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
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("CorsPolicy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddScoped<DbContext>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddCors(options => options.AddPolicy("CorsPolicy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddSwaggerGen(x => x.SwaggerDoc("PortfolioTrackerAPI", new OpenApiInfo
            {
                Title = " PortfolioTrackerAPI",
                Description = "This API is used for performing CRUD operations on all the Entities",
                Version = "1.0.0.0"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/PortfolioTrackerAPI/swagger.json", "PortfolioTrackerAPI");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

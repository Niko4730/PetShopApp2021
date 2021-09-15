using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NGP.PetShop2021.EF;
using NGP.PetShop2021.EF.Repositories;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Domain.IRepositories;
using NGP.PetShopApp2021.Domain.Services;
using NGP.PetShopApp2021.Infrastructure.Data.Repositories;

namespace NGP.PetShopApp2021._WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "NGP.PetShopApp2021._WebApi", Version = "v1"});
            });
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );
            services.AddDbContext<PetShopDbContext>(
                options =>
                {
                    options
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=petShop.db");
                });
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<IPetRepository, PetRepositoryInMemory>();
            services.AddScoped<IPetService, PetService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NGP.PetShopApp2021._WebApi v1"));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<PetShopDbContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
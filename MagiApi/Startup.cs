using MagiApi.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MagiApi.Interfaces;
using MagiApi.Services;
using AutoMapper;
using System;
using System.Linq;
using MagiApi.Migrations;
using System.Reflection;
using System.IO;
using System.Security.Policy;

namespace MagiApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            services.AddDbContext<EventStaffContext>(options =>
            {
                options.UseSqlServer(Configuration["connectionStrings:eventStaffConnectionString"]);
            });

            //Mapping repositories
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipantRepository, UserRepository>();

            //AppDomain.CurrentDoain.GetAssemblies() scans for assemblies to add
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("LibraryOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "MagiServerApi",
                    Version = "1",
                    Description="API to manager Events",
                    Contact= new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "niall.maguire@zoho.com",
                        Name = "Niall Maguire",
                        Url = new Uri("Http://www.google.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT Licecne",
                        Url = new Uri("https://opensource.org/licences/MIT")
                    }
                });
                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(commentsFullPath);

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Controls routing decisions
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/LibraryOpenApiSpecification/swagger.json", "Magiserver API");
                setupAction.RoutePrefix = "";
            });

        }
    }
}

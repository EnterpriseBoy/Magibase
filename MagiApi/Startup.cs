using MagiApi.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MagiApi.Interfaces;
using MagiApi.Services;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Mvc.Formatters;

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

        }
    }
}

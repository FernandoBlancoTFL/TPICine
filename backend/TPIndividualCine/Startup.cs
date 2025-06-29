using Application.InterfaceService;
using Application.Services;
using Data;
using Data.Commands;
using Domain.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;
using Domain.Queries;
using Data.Queries;

namespace TPIndividualCine
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
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            //EF CORE
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
                {
                    return new SqlConnection(connectionString);
                });

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IFuncionService, FuncionService>();
            services.AddTransient<IPeliculaService, PeliculaService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IQueryPelicula, QueryPeliculas>();
            services.AddTransient<IQuerySala, QuerySalas>();
            services.AddTransient<IQueryFuncion, QueryFunciones>();
            services.AddTransient<IQueryTicket, QueryTickets>();
            services.AddTransient<IQueryGeneric, QueryGeneric>();

            services.AddCors(options =>
            {
                options.AddPolicy("AnyAllow", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AnyAllow");

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TpIndividual2.API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"TpIndividual2 {groupName}",
                    Version = groupName,
                    Description = "TpIndividual2 API",
                });
            });
        }

    }
}

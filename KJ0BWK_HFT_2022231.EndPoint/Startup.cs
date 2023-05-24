using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KJ0BWK_HFT_2022231.EndPoint.Services;
using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace KJ0BWK_HFT_2022231.EndPoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FootballDbContext>();

            services.AddTransient<IRepository<Player>, PlayerRepository>();
            services.AddTransient<IRepository<Club>, ClubRepository>();
            services.AddTransient<IRepository<Owner>, OwnerRepository>();

            services.AddTransient<IPlayerLogic, PlayerLogic>();
            services.AddTransient<IClubLogic, ClubLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "KJ0BWK_HFT_2022231.Endpoint",
                    Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint
                ("/swagger/v1/swagger.json", "KJ0BWK_HFT_2022231.Endpoint v1"));
                
            }
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:28336"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}

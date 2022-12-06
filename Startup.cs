using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCors
{
    public class  Startup
    {
        private readonly string _MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set ;}
        //chamando metodo

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCors", Version = "v1"});

            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyCors, builder =>
                {
                   // builder.WithOrigins("http://jonatasx-001-site1.ftempurl.com");
                   builder.SetIsOriginAllowed(origin => new Uri (origin).Host =="logalhost")
                   .AllowAnyHeader().AllowAnyMethod();

                });
            
            
        });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCors v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_MyCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
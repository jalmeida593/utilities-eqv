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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Utilities_Eqv.Model;
using Utilities_Eqv.Repository.Abst;
using Utilities_Eqv.Repository.Impl;

namespace Utilities_Eqv
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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Utilities API",
                    Description = "API de Utilitarios",
                    TermsOfService = new Uri("http://www.equivida.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Soporte",
                        Email = string.Empty,
                        Url = new Uri("http://equivida.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia propietaria de Equivida",
                        Url = new Uri("http://equivida.com"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.**
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //agregar aqui las interfaces con sus impl
            services.AddTransient<IUploadFileService, UploadFileService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "sise_api v1");
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "sise_api v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

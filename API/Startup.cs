using ChallengeTecnicoEngee.API.Configurations;
using Domain.Common;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

namespace ChallengeTecnicoEngee.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add DbContext
            services.AddDatabaseModule(Configuration);

            //Add Dependencies
            services.AddServiceModule();

            // Add Controllers
            services.AddControllers();

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Challenge Tecnico",
                    Version = "v1",
                    Description = $"Challenge para Engee, creado con tecnologia NET Core 6.0 \n " +
                    $"\n -Se siguio un patron por capas, con un modelo de configuracion de entidades FLUENT y utilizando configuracion customizada, pensada para ser mas escalable \n" +
                    $"\n -Al momento de crear las entidades, se piensan en dos tipos base de entidades, una que sea para los tipos (parametria) que puedan llegarse a agregar y el otro" +
                    $"\n -es para mantener una auditoria de las entradas a la Db, aparte de que es en esta que me aseguro que todos los Ids sean unicos" +
                    $"\n -Utilizo un modelado de base de datos utilizando EF Core y un patron CodeFirst \n " +
                    $"\n -Se agrega tambien inyeccion de dependencias para darle mas claridad de responsabilidad a cada clase \n" +
                    $"\n -Se crea e implementa un middleware de Exception Handler, para poder liberar performance en las llamadas \n",
                    Contact = new OpenApiContact()
                    {
                        Name = "Alejandro Jacobo Guerrero",
                        Url = new Uri("https://github.com/AleJacobo"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }


        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChallengeIntuit v.1"));
            }

            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var response = new Result();
                    var ex = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                    if (ex.GetType() == typeof(APIException))
                    {
                        await response.Fail(ex.Message);
                    }
                    else
                    {
                        await response.Fail("No se ha podido ejecutar la operacion");
                    }
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.BodyWriter.WriteAsync(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(response)));
                });
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseDatabaseMigration(serviceProvider, env);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

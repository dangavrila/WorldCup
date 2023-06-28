using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorldCup.ApplicationService.DI;
using WorldCup.WebAPI.Filters;
using static System.Net.Mime.MediaTypeNames;

namespace WorldCup.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<NotImplementexExFilter>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                    new BadRequestObjectResult(context.ModelState)
                    {
                        ContentTypes =
                        {
                            Application.Json,
                            Application.Xml
                        }
                    };
            })
            .AddXmlSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServiceModule();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler(exceptionHandlerApp =>
                {
                    exceptionHandlerApp.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = Text.Plain;

                        await context.Response.WriteAsync("An exception was thrown.");

                        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync(" The file was not found.");
                        }

                        if (exceptionHandlerPathFeature?.Path == "/")
                        {
                            await context.Response.WriteAsync(" Page: Home.");
                        }
                    });
                });

                //app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
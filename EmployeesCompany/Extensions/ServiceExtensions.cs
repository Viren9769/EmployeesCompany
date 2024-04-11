using Contracts;
using LoggerService;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeesCompany.Extensions
{
    public static class ServiceExtensions
    {

        //  we are going to da is configure CORS in our application 
        // We are using basic CORS policy settings because allowing any origin, 
       // method, and header is okay for now.But we should be more
       // restrictive with those settings in the production environment.More
       // precisely, as restrictive as possible.
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
        });

        //ASP.NET Core applications are by default self-hosted, and if we want to 
        //host our application on IIS, we need to configure an IIS integration which
        //will eventually help us with the deployment to IIS.To do that, we need to
        //add the following code to the ServiceExtensions class:
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
             services.Configure<IISOptions>(options =>
             {
             });


        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    }
}

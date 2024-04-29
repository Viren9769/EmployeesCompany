using Contracts;
using LoggerService;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Repository;
using System;
using static System.Net.Mime.MediaTypeNames;
using Service;
using Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Marvin.Cache.Headers;


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

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();


        

        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        builder.AddMvcOptions(config => config.OutputFormatters.Add(new
        CsvOutputFormatter()));

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;                                     //  ReportApiVersions adds the API version to the response header.
                opt.AssumeDefaultVersionWhenUnspecified = true;                 //  AssumeDefaultVersionWhenUnspecified does exactly that. It specifies the default API version if the client doesn’t send one.
                opt.DefaultApiVersion = new ApiVersion(1, 0);                 //  DefaultApiVersion sets the default version count.

                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }

        public static void ConfigureResponsecaching(this IServiceCollection services) => services.AddResponseCaching();

        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) => services.AddHttpCacheHeaders(
             (expirationOpt) =>
             {
                 expirationOpt.MaxAge = 65;
                 expirationOpt.CacheLocation = CacheLocation.Private;
             },
 (validationOpt) =>
 {
     validationOpt.MustRevalidate = true;
 });



    }
}

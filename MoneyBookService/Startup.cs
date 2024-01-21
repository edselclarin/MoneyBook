using Microsoft.OpenApi.Models;
using MoneyBookService.WebApi.Filters;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MoneyBookService
{
    public class Startup
    {
        public static string ServiceName => "MoneyBook Service API";
        public static string ServiceVersion => "1.0";
        public static string FullServiceName => $"{ServiceName} - v{ServiceVersion}";

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseWebSockets();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetPreflightMaxAge(TimeSpan.FromSeconds(2501));
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ServiceName);
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionAsHttpErrorFilter));
                options.Filters.Add(typeof(ValidateExceptionAttribute));
                options.Filters.Add(new AddHeaderAttribute("Server", ServiceVersion));
                options.Filters.Add(new AddHeaderAttribute("Access-Control-Allow-Origin", "*"));
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                opt.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = ServiceName,
                    Description = FullServiceName,
                });
                c.EnableAnnotations();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
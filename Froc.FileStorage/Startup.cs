using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using Forc.FileStorage.Services;

namespace Forc.FileStorage
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("allowedOrigins", policy =>
                {
                    policy.WithOrigins(_configuration["WebAPIAplicationURL"]).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson();

            services.Configure<FileStorageSettings>(_configuration.GetSection("FileStorageDB"));

            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("allowedOrigins");

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}");
            });
        }
    }
}

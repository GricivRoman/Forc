
using ForcWebApi.Infrastructure;

namespace ForcWebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}");
            });
        }
    }
}

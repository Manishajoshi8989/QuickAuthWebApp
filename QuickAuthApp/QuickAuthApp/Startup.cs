using CpcPumpsSalesTool.Core.Application;
using Domain.Services.Auth;
using Microsoft.OpenApi.Models;

namespace QuickAuthApp
{
    public class Startup
    {
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });
            services.AddSingleton<IOtpService, OtpService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger"; // Change the route prefix
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controller endpoints
            });
        }
    }
}
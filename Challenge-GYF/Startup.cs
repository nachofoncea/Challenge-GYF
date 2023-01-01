using ChallengeGYF.Shared.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace ChallengeGYF.API
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

     
            services.AddControllers()
                  .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        // required if AllowCredentials is set also
                        .SetIsOriginAllowed(s => true)
                        //.AllowAnyOrigin()
                        .AllowAnyMethod()  // doesn't work for DELETE!
                                           //  .WithMethods("DELETE")
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });


            IOCRegister.AddRegistration(services);
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });


            services.AddSwaggerGen (c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChallengeGYF.API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChallengeGYF.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

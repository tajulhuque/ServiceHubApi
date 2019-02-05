using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceHubApi.Data_Access;

namespace ServiceHubApi
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials() );
            });

            services.AddDbContext<ServiceEventContext>(opt => opt.UseInMemoryDatabase("serviceEventDB"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IRetentionPolicyMatcher, RetentionPolicyMatcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCors("CorsPolicy");

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();




            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ServiceEventContext>();
                SeedData(context); 
            }

            app.UseMvc(routes =>
            {
                

                routes.MapRoute(
                    name: "default",
                    template: "{controller=ServiceHubAdmin}/{action=Index}/{id?}");
            });
        }

        private void SeedData(ServiceEventContext context)
        {
            var retentionPolicy1 = new RetentionPolicy {
                Id = 1,
                RetentionTimeHours = 1,
                ForSeverity = 3,
                IsRetainForever = false,
                Description = "The first RP"
            };

            var retentionPolicy2 = new RetentionPolicy {
                Id = 2,
                RetentionTimeHours = 2,
                ForSeverity = 3,
                IsRetainForever = false,
                Description = "The second RP"
            };

            context.RetentionPolicies.Add(retentionPolicy1);
            context.RetentionPolicies.Add(retentionPolicy2);
            context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ContactBook.Persistence;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace ContactBook
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

            //services.AddControllers();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(
                                             new SlugifyParameterTransformer()));
            });//.AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactBook", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(options =>
                      options.UseNpgsql(Configuration.GetConnectionString("ContactBookConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactBook v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private class SlugifyParameterTransformer : IOutboundParameterTransformer
        {
            public string TransformOutbound(object value)
            {
                if (value == null) { return null; }

                // Slugify value
                return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
            }
        }
    }
}

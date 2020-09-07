using AutoMapper;
using iMovie.Api.Config;
using iMovie.Core.Movie;
using iMovie.Core.Movie.Interface;
using iMovie.Facade.Omdb;
using iMovie.Facade.Omdb.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iMovie.Api
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
            services.AddControllers();

            services.AddAutoMapper(typeof(OrganizationProfile));           

            services.AddTransient<ISearchMovie, SearchMovie>();
            services.AddTransient<IOmdbApi, OmdbApi>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API from Movie Info"  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

              app.UseSwagger();  
  
               // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
               // specifying the Swagger JSON endpoint.  
               app.UseSwaggerUI( c =>  
               {  
                   c.SwaggerEndpoint( "/swagger/v1/swagger.json", "iMovie API V1" );
                   c.RoutePrefix = string.Empty;
               } );  
        }
    }
}

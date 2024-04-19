using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
namespace TiendaServicios.Api.Gateway
{
    public class Startup
    { 


    
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration;


        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddOcelot();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            
            }

            app.UseRouting();   
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
         await   app.UseOcelot();    
        
        
        
        
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Productos.Services;
using Productos.Services.Api;

namespace Productos
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Config = config;
        }

        public IConfiguration Config { get; }

        public void ConfigurationService(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<ICategoriaApi, CategoriaService>();
            services.AddScoped<ISubCategoriaApi, SubCategoriaServices>();

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Config.GetConnectionString("defaultConnection")));
        }

        public void Configuration(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
using Address_Book_API.Domain.Interfaces;
using Address_Book_API.Domain.Models;
using Address_Book_API.Domain.Repository;
using Address_Book_API.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Address_Book_API
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
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSwaggerGen();
            services.AddSingleton<IMongoDbSettings>(x => x.GetRequiredService<IOptions<MongoDbSettings>>().Value);          
            services.AddSingleton<IMongoClient, MongoClient>(x =>
             {
                 var settings = x.GetRequiredService<IMongoDbSettings>();
                 return new MongoClient(settings.ConnectionString);
             });
            services.AddSingleton<IContactRepository, ContactRepository>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Address_Book_API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

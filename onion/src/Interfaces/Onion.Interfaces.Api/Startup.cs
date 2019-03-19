using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Core.Application.Services.Orders;
using Onion.Core.Application.Services.Users;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Services;
using Onion.Infrastructure.Repositories.MongoDb;
using Swashbuckle.AspNetCore.Swagger;

namespace Onion.Interfaces.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Onion Architecture", Version = "v1" });
            });


            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IOrdersDomainService, OrdersDomainService>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddSingleton<IProductRepository, ProductsRepository>();
            services.AddSingleton<IInventoryRepository, InventoryRepository>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Onion Architecture");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Core.Application.Interfaces;
using Onion.Core.Application.Services.Inventory;
using Onion.Core.Application.Services.Orders;
using Onion.Core.Application.Services.Products;
using Onion.Core.Application.Services.Users;
using Onion.Core.Domain.Repositories;
using Onion.Core.Domain.Services;
using Onion.Infrastructure.Repositories.MongoDb;
using Onion.Infrastructure.StockDispatcher.Email;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Onion Architecture", Version = "v1" });
            });


            services.AddScoped<IOrdersDomainService, OrdersDomainService>();
            
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IProductsService, ProductsService>();
            
            services.AddScoped<IStockDispatcher, StockDispatcher>();
            
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddSingleton<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IInventoryRepository, InventoryRepository>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
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

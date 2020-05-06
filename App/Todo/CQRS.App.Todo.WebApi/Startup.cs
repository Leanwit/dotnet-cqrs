using CQRS.Shared.Domain.Bus.Command;
using CQRS.Shared.Domain.Bus.Query;
using CQRS.Shared.Infrastructure.Bus.Command;
using CQRS.Shared.Infrastructure.Bus.Query;
using CQRS.Todo.Items.Application;
using CQRS.Todo.Items.Application.Create;
using CQRS.Todo.Items.Application.Find;
using CQRS.Todo.Items.Domain;
using CQRS.Todo.Items.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS.App.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<CommandBus, InMemoryCommandBus>();
            services.AddScoped<CommandHandler<CreateItemCommand>, CreateItemCommandHandler>();

            services.AddScoped<QueryBus, InMemoryQueryBus>();
            services.AddScoped<QueryHandler<FindItemQuery, ItemResponse>, FindItemQueryHandler>();
            services.AddSingleton<ItemRepository, InMemoryItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
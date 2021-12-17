using CQRS.Todo.Items.Domain;
using CQRS.Todo.Items.Infrastructure;
using CQRS.Todo.Shared;
using CQRS.Todo.Shared.Domain.Bus.Commands;
using CQRS.Todo.Shared.Domain.Bus.Queries;
using CQRS.Todo.Shared.Infrastructure.Bus.Commands;
using CQRS.Todo.Shared.Infrastructure.Bus.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS.App.WebApi;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddCommandServices(typeof(Command).Assembly);
        services.AddScoped<CommandBus, InMemoryCommandBus>();

        services.AddQueryServices(typeof(Query).Assembly);
        services.AddScoped<QueryBus, InMemoryQueryBus>();

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
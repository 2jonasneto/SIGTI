using MudBlazor.Services;
using Sigti.Web.Components;
using Sigti.Data.Base;
using Sigti.Application.Interfaces;
using Sigti.Core.Interfaces;
using Sigti.Application;
using Sigti.Application.Handlers;
using Microsoft.EntityFrameworkCore;
namespace Sigti.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddMudServices();
            builder.Services.AddDbContext<SigtiContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
            builder.Services.AddAutoMapper(typeof(Sigti.Application.Base.DTOMapping));
            builder.Services.AddScoped<IComputadorQueryHandler, ComputadorQueryHandler>();
            builder.Services.AddScoped<ISetorQueryHandler, SetorQueryHandler>();
            builder.Services.AddScoped<ICommandHandler<AdicionarComputadorCommand>, ComputadorCommandHandler>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            var context = builder.Services.BuildServiceProvider().GetRequiredService<SigtiContext>();
            context.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

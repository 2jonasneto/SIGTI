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

           
            

            builder.Services.AddScoped<ICommandHandler<AdicionarComputadorCommand>, ComputadorCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarComputadorCommand>, ComputadorCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverComputadorCommand>, ComputadorCommandHandler>();
            builder.Services.AddScoped<IComputadorQueryHandler, ComputadorQueryHandler>();

            builder.Services.AddScoped<ICommandHandler<AdicionarLocalizacaoCommand>, LocalizacaoCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarLocalizacaoCommand>, LocalizacaoCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverLocalizacaoCommand>, LocalizacaoCommandHandler>();
            builder.Services.AddScoped<ILocalizacaoQueryHandler, LocalizacaoQueryHandler>();

            builder.Services.AddScoped<ICommandHandler<AdicionarSetorCommand>, SetorCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarSetorCommand>, SetorCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverSetorCommand>, SetorCommandHandler>();
            builder.Services.AddScoped<ISetorQueryHandler, SetorQueryHandler>();


            builder.Services.AddScoped<ICommandHandler<AdicionarImpressoraCommand>, ImpressoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarImpressoraCommand>, ImpressoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverImpressoraCommand>, ImpressoraCommandHandler>();
            builder.Services.AddScoped<IImpressoraQueryHandler, ImpressoraQueryHandler>();


            builder.Services.AddScoped<ICommandHandler<AdicionarControladoraCommand>, ControladoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarControladoraCommand>, ControladoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverControladoraCommand>, ControladoraCommandHandler>();
            builder.Services.AddScoped<IControladoraQueryHandler, ControladoraQueryHandler>();


            builder.Services.AddScoped<ICommandHandler<AdicionarAcessoControladoraCommand>, AcessoControladoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AtualizarAcessoControladoraCommand>, AcessoControladoraCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RemoverAcessoControladoraCommand>, AcessoControladoraCommandHandler>();
            builder.Services.AddScoped<IAcessoControladoraQueryHandler, AcessoControladoraQueryHandler>();

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

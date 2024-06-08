global using Sigti.Data;
using MudBlazor.Services;
using Sigti.Web.Components;
using Sigti.Data.Base;
using Sigti.Application.Interfaces;
using Sigti.Core.Interfaces;
using Sigti.Application;
using Sigti.Application.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Sigti.Web.Components.Account;
using Microsoft.AspNetCore.Identity;

namespace Sigti.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddMudServices();
            builder.Services.AddDbContext<SigtiContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
            builder.Services.AddAutoMapper(typeof(Sigti.Application.Base.DTOMapping));

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
               .AddIdentityCookies();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SigtiContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

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
            var roleManager = builder.Services.BuildServiceProvider()
    .GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new string[] { "Admin", "User" };
            var user = new string[] { "admin@sig", "user@sig" };

            IdentityResult result;
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    result = await roleManager
                        .CreateAsync(new IdentityRole(role));

                    if (result.Succeeded)
                    {
                        var userManager = builder.Services.BuildServiceProvider()
                            .GetRequiredService<UserManager<ApplicationUser>>();

                        var config = builder.Services.BuildServiceProvider()
                            .GetRequiredService<IConfiguration>();

                        var admin = await userManager
                            .FindByEmailAsync(role == "Admin" ? user[0] : user[1]);
                        if (admin == null)
                        {
                            admin = new ApplicationUser()
                            {
                                UserName = role == "Admin" ? user[0] : user[1],
                                Email = role == "Admin" ? user[0] : user[1],
                                EmailConfirmed = true
                            };
                            result = await userManager
                                .CreateAsync(admin, role+"@sig10");

                            if (result.Succeeded)
                            {
                                result = await userManager
                                    .AddToRoleAsync(admin, role);
                                if (!result.Succeeded)
                                {
                                    // todo:processar erros
                                }
                            }
                        }
                    }
                }


            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.MapAdditionalIdentityEndpoints();
            app.Run();
        }
    }
}

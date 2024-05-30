using Microsoft.EntityFrameworkCore;
using Sigti.Application.Handlers;
using Sigti.Application.Interfaces;
using Sigti.Application;
using Sigti.Core.Interfaces;
using Sigti.Web.Components;
using Sigti.Data.Base;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<SigtiContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
builder.Services.AddAutoMapper(typeof(Sigti.Application.Base.DTOMapping));
builder.Services.AddScoped<IComputadorQueryHandler, ComputadorQueryHandler>();
builder.Services.AddScoped<ISetorQueryHandler, SetorQueryHandler>();
builder.Services.AddScoped<ICommandHandler<AdicionarComputadorCommand>, ComputadorCommandHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMudServices();

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
var context = builder.Services.BuildServiceProvider()
             .GetRequiredService<Sigti.Data.Base.SigtiContext>();
context.Database.Migrate();
app.Run();

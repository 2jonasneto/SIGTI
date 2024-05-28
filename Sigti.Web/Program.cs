using Microsoft.EntityFrameworkCore;
using Sigti.Data.Base;
using Sigti.Web.Components;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<SigtiContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));


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
             .GetRequiredService<SigtiContext>();
context.Database.Migrate();
app.Run();

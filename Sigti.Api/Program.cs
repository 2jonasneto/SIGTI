using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigti.Application;
using Sigti.Application.Base;
using Sigti.Application.DTO;
using Sigti.Application.Handlers;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using Sigti.Data.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SigtiContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
builder.Services.AddAutoMapper(typeof(DTOMapping));
builder.Services.AddScoped <IComputadorQueryHandler, ComputadorQueryHandler>();    
builder.Services.AddScoped <ICommandHandler<AdicionarComputadorCommand>, ComputadorCommandHandler>();    
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var context = builder.Services.BuildServiceProvider().GetRequiredService<SigtiContext>();
context.Database.Migrate();


app.MapGet("v1/Computadores", ([FromServices] IComputadorQueryHandler query) =>
{
        return query.ListaCmputadores();
})
.WithName("GetComputadores")
.WithOpenApi();

app.MapGet("v2/Computadores", ([FromServices] IComputadorQueryHandler query) =>
{
    return query.GridComputadores();
})
.WithName("GetGridComputadores")
.WithOpenApi();

app.MapPost("v1/Computadores", async ([FromServices] ICommandHandler<AdicionarComputadorCommand> cmd) =>
{
    for (int i = 1; i < 25; i++)
    {
        var pc = new AdicionarComputadorCommand($"FIN-{i}", "Intel Core i5-7267U @ 3.10GHz".ToUpper(), "16 GB", "SSD 240 GB", $"192.168.0.{i}", "123456789", "FINANCEIRO", "User"+i,$"{i*10}", "WINDOWS 10 PRO", "SYSTEM", Guid.Parse("7990de56-a99f-430e-b3bf-3ecddc8fe038"), Guid.Parse("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), " ");
        var result = await cmd.Execute(pc);
       
    }
    return "";

})
.WithName("PostComputadores")
.WithOpenApi();

app.Run();


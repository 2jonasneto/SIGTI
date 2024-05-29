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
builder.Services.AddAutoMapper(typeof(Sigti.Application.Base.DTOMapping));
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
    var pc = new AdicionarComputadorCommand("TESTE", "INTEL", "4", "256", "10.0.0.1", "123456789", "WWW", "eu", "12334", "indows", "eu", Guid.NewGuid(), Guid.NewGuid(), "vamo ver");
  var result= await cmd.Execute(pc);
    return ((GenericCommandResult)result).Message;
    
})
.WithName("PostComputadores")
.WithOpenApi();

app.Run();


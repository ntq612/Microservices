using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

////Add services to container
///
///----------------------
///Infrastructure - EF Core
///Application - MediatR
///API - Carter, HealthCheck,....
///

builder.Services
    .AddApplicationServices()
    .AddInfrastuctureServices(builder.Configuration)
    .AddApiServices();

//-------------------------



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

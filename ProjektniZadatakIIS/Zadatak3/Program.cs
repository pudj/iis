using SoapCore;
using System.ServiceModel;
using Zadatak3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventService, EventService>();

var app = builder.Build();

app.UseSoapEndpoint<IEventService>("/EventService.asmx", new SoapEncoderOptions());

app.MapGet("/", () => "Hello World!");

app.Run();

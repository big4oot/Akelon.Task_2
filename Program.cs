using System.Reflection;
using Akelon.Task_2.DAL;
using Akelon.Task_2.DAL.Repositories;
using Akelon.Task_2.Presentation;
using Akelon.Task_2.Utils;
using Akelon.Task_2.Utils.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());;
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(new Config());
builder.Services.AddScoped<ExcelContext>();
builder.Services.AddTransient<ClientsRepository>();
builder.Services.AddTransient<OrdersRepository>();
builder.Services.AddTransient<ProductsRepository>();

builder.Services.AddSingleton<UI>();

IHost host = builder.Build();

UI ui = host.Services.GetService<UI>();
await ui.Show();


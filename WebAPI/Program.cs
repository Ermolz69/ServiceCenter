using Microsoft.EntityFrameworkCore;
using ServiceCenter.Application.Interfaces;
using ServiceCenter.Application.Services;
using ServiceCenter.Infrastructure.Data;
using ServiceCenter.Infrastructure.Repositories;
using YourSolution.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Connect MSSQL by appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
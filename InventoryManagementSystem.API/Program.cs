using FluentValidation;
using FluentValidation.AspNetCore;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using InventoryManagementSystem.Infraestructure.Repositories;
using InventoryManagementSystem.Infraestructure.Validators;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryManagerSystemDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagerDB")));
builder.Services.AddControllers();
builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IRoleEmployeeRepository, RoleEmployeeRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ProductBrandDto>, ProductBrandValidator>();
builder.Services.AddScoped<IValidator<ClientDto>, ClientValidator>();
builder.Services.AddScoped<IValidator<EmployeeDto>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<DocumentTypeDto>, DocumentTypeValidator>();
builder.Services.AddScoped<IValidator<RoleEmployeeDto>, RoleEmployeeValidator>();

builder.Services.AddCors(options => options.AddPolicy(myAllowSpecificOrigins, builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

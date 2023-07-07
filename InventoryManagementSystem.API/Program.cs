using FluentValidation;
using FluentValidation.AspNetCore;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Core.Services;
using InventoryManagementSystem.Infraestructure.Migrations;
using InventoryManagementSystem.Infraestructure.Repositories;
using InventoryManagementSystem.Infraestructure.Validators;
using Microsoft.EntityFrameworkCore;

var _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryManagerSystemDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagerDB")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeUserService, EmployeeUserService>();
builder.Services.AddScoped<IMunicipalityCountryService, MunicipalityCountryService>();
builder.Services.AddScoped<IProductBrandService, ProductBrandService>();
builder.Services.AddScoped<IRoleEmployeeService, RoleEmployeeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ProductBrandDto>, ProductBrandValidator>();
builder.Services.AddScoped<IValidator<ClientDto>, ClientValidator>();
builder.Services.AddScoped<IValidator<EmployeeDto>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<DocumentTypeDto>, DocumentTypeValidator>();
builder.Services.AddScoped<IValidator<RoleEmployeeDto>, RoleEmployeeValidator>();
builder.Services.AddScoped<IValidator<MunicipalityCountryDto>, MunicipalityCountryValidator>();

builder.Services.AddCors(options => options.AddPolicy(name: _myAllowSpecificOrigins, builder =>
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

app.UseCors(_myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

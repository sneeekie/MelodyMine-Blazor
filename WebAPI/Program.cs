using AutoMapper;
using BLL.Repositories.Implementations;
using BLL.Repositories.Interfaces;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL;
using DAL.Entities;
using BLL.DTOs;
using BLL.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddDbContext<EfDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITemplateRepository<Template>, TemplateRepository<Template>>();
builder.Services.AddScoped<ITemplateService<TemplateDto>, TemplateService<Template, TemplateDto>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
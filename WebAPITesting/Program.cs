using BAL_CRUD.Service;
using DAL_CRUD.DATA;
using DAL_CRUD.Interface;
using DAL_CRUD.Model;
using DAL_CRUD.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext> (option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDAspNetCore5WebAPI", Version = "v1" });
//});
//builder.AddHttpClient();
//builder.AddTransient<IRepository<Person>, RepositoryPerson>();
//builder.AddTransient<PersonService, PersonService>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IRepository<Person>, RepositoryPerson>();
builder.Services.AddTransient<PersonService, PersonService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

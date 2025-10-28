using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Interceptor;
using Presistence.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnecDBConnectiontionMohrez"))
    .AddInterceptors(new TimestampInterceptor())
);


builder.Services.AddScoped<IDBContext, DBContext>();


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

using Application.Interface;
using Application.Interface.IInfrastructure;
using Application.Interface.IUsecase;
using Application.Usecase;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Interceptor;
using TelegramServiceLog;

var builder = WebApplication.CreateBuilder(args);



//configs:
builder.Configuration.AddJsonFile("TelegramServiceConfig.json", optional: false, reloadOnChange: true);
builder.Services.Configure<TelegramServiceConfig>(
    builder.Configuration.GetSection(""));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnecDBConnectiontionMohrez"))
    .AddInterceptors(new TimestampInterceptor())
);


builder.Services.AddScoped<IDBContext, DBContext>();

//Usecases
builder.Services.AddScoped<IGetConfigUseCase, GetConfigUseCase>();


//infrustructure
builder.Services.AddScoped<ITelegramService, TelegramService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

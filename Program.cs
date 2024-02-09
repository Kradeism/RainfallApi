using RainfallApi.Repositories;
using RainfallApi.Repositories.Interfaces;
using RainfallApi.Services;
using RainfallApi.Services.Interfaces;
using RainfallApi.Services.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEnvironmentApiService, EnvironmentApiService>();
builder.Services.AddSingleton<IRainfallReadingRepository, RainfallReadingRepository>();
builder.Services.AddSingleton<IRainfallReadingService, RainfallReadingService>();
builder.Services.AddSingleton<IErrorHandlingService, ErrorHandlingService>();
builder.Services.AddSingleton<IValidationService, ValidationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

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

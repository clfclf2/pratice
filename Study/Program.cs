using Microsoft.EntityFrameworkCore;
using Study.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. 설정 파일(appsettings.json)에서 연결 문자열을 미리 가져와 봅니다.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. 만약 문자열이 비어있다면, 에러를 내서 원인을 바로 알 수 있게 합니다.
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("에러: appsettings.json 파일에서 'DefaultConnection' 정보를 찾을 수 없습니다! 파일명이나 오타를 확인해주세요.");
}

// 3. 연결 문자열이 확인되었을 때만 DB 서비스를 등록합니다.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

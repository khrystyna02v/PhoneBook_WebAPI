using PhoneBook_webAPI;
using PhoneBook_webAPI.ExternalProviders;
using PhoneBook_webAPI.Managers;
using PhoneBook_webAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IManager, JsonManager>();
builder.Services.AddScoped<INationalizeProvider, NationalizeProvider>();
builder.Services.AddScoped<IApiFirstProvider, ApiFirstProvider>();
builder.Services.AddScoped<IRestCountriesProvider, RestCountriesProvider>();
builder.Services.AddScoped<ICountryPredictionManager, CountryPredictionManager>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

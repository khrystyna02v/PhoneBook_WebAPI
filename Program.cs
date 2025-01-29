using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.ExternalProviders;
using PhoneBook_webAPI.Managers;
using PhoneBook_webAPI.Middleware;
using PhoneBook_webAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<INationalizeProvider, NationalizeProvider>();
builder.Services.AddScoped<IRestCountriesProvider, RestCountriesProvider>();
builder.Services.AddScoped<ICountryPredictionManager, CountryPredictionManager>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

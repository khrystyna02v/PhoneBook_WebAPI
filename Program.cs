using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.ExternalProviders;
using PhoneBook_webAPI.Managers;
using PhoneBook_webAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddScoped<IManager, JsonManager>();
builder.Services.AddScoped<INationalizeProvider, NationalizeProvider>();
builder.Services.AddScoped<IRestCountriesProvider, RestCountriesProvider>();
builder.Services.AddScoped<ICountryPredictionManager, CountryPredictionManager>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    //    context.Database.EnsureCreated();
    //}
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

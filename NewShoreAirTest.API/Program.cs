using Microsoft.EntityFrameworkCore;
using NewShortAirTest.Bussines;
using NewShortAirTest.Bussines.Flights;
using NewShortAirTest.DataAccess.Data;
using NewShortAirTest.DataAccess.Data.Flights;
using NewShortAirTest.Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer("name=DB.NewShoreAir"));
builder.Services.AddTransient<SeedDb>();

string baseAddress = builder.Configuration.GetValue<string>("ApiUrl");
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

builder.Services.AddTransient<IRepository, Repository>();
// Bussines Components
builder.Services.AddScoped<IFlightBS,FlightBS>();
// DAL Components
builder.Services.AddScoped<IFlightDAL,FlightDAL>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//SeedData(app);
/*void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}*/

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();

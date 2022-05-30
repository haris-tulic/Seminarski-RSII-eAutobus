using eAutobus.Database;
using eAutobus.Security;
using eAutobus.Services;
using eAutobus.Services.Interfaces;
using eAutobus.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IAutobusService, AutobusService>();
builder.Services.AddScoped<IAutobusVozacService, AutobusVozacService>();
builder.Services.AddScoped<ICjenovnikService, CjenovnikService>();
builder.Services.AddScoped<IGradService, GradService>();
builder.Services.AddScoped<IKartaService, KartaService>();
builder.Services.AddScoped<IRasporedVoznjeService, RasporedVoznjeService>();
builder.Services.AddScoped<IStanicaService, StanicaService>();
builder.Services.AddScoped<ITipKarteService, TipKarteService>();
builder.Services.AddScoped<IVozacService, VozacService>();
builder.Services.AddScoped<IVrstaKarteService, VrstaKarteService>();
builder.Services.AddScoped<IZonaService, ZonaService>();
builder.Services.AddScoped<IAutobusService, AutobusService>();
builder.Services.AddScoped<IGarazaService, GarazaService>();
builder.Services.AddScoped<IUlogeService, UlogeService>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IKartaKupacService, KartaKupacService>();
builder.Services.AddScoped<IRecenzijaService, RecenzijaService>();
builder.Services.AddScoped<IPlatiOnlineService, PlatiOnlineService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connection = builder.Configuration.GetConnectionString("eAutobus");
builder.Services.AddDbContext<eAutobusi>(options => options.UseSqlServer(connection));
builder.Services.AddAuthentication("BasicAuthentification")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentification", null);
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

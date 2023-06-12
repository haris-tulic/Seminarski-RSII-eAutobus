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

builder.Services.AddTransient<IKupacService, KupacService>();
builder.Services.AddTransient<IAutobusService, AutobusService>();
builder.Services.AddTransient<IAutobusVozacService, AutobusVozacService>();
builder.Services.AddTransient<ICjenovnikService, CjenovnikService>();
builder.Services.AddTransient<IGradService, GradService>();
builder.Services.AddTransient<IKartaService, KartaService>();
builder.Services.AddTransient<IRasporedVoznjeService, RasporedVoznjeService>();
builder.Services.AddTransient<IStanicaService, StanicaService>();
builder.Services.AddTransient<ITipKarteService, TipKarteService>();
builder.Services.AddTransient<IVozacService, VozacService>();
builder.Services.AddTransient<IVrstaKarteService, VrstaKarteService>();
builder.Services.AddTransient<IZonaService, ZonaService>();
builder.Services.AddTransient<IAutobusService, AutobusService>();
builder.Services.AddTransient<IGarazaService, GarazaService>();
builder.Services.AddTransient<IUlogeService, UlogeService>();
builder.Services.AddTransient<IKorisnikService, KorisnikService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IKartaKupacService, KartaKupacService>();
builder.Services.AddTransient<IRecenzijaService, RecenzijaService>();
builder.Services.AddTransient<IPlatiOnlineService, PlatiOnlineService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eAutobusi>(options => options.UseSqlServer(connection));
builder.Services.AddAuthentication("BasicAuthentification")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentification", null);
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

//using (var scope = app.Services.CreateScope())
//{
//    var dataContext = scope.ServiceProvider.GetRequiredService<eAutobusi>();
//    dataContext.Database.EnsureCreated();
//}

app.Run();

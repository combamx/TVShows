using Microsoft.EntityFrameworkCore;
using TVShowsAPI.Data.Models;
using TVShowsAPI.Repositories.Interfaces;
using TVShowsAPI.Repositories.Repositories;

var builder = WebApplication.CreateBuilder ( args );

// Configurar el cargador de configuración para soportar múltiples entornos
builder.Configuration
    .SetBasePath ( Directory.GetCurrentDirectory ( ) )
    .AddJsonFile ( "appsettings.json" , optional: false , reloadOnChange: true )
    .AddJsonFile ( $"appsettings.{builder.Environment.EnvironmentName}.json" , optional: true ) // Cargar configuraciones específicas del entorno
    .AddEnvironmentVariables ( );

// Add services to the container.
builder.Services.AddScoped<ITvShowRepository , TvShowRepository> ( );
builder.Services.AddScoped<IUserRepository , UserRepository> ( );

builder.Services.AddScoped<ITvShowContextRepository , TvShowContextRepository> ( );
builder.Services.AddScoped<IUserContextRepository , UserContextRepository> ( );


var cnn = builder.Configuration.GetConnectionString ( "DefaultConnection" );
// Configura el contexto de la base de datos
builder.Services.AddDbContext<TVShowDataContext> ( options => options.UseSqlServer ( cnn ) );


// Configurar CORS para permitir solicitudes de cualquier origen
builder.Services.AddCors ( options =>
{
    options.AddPolicy ( "AllowAllOrigins" ,
        builder => builder.AllowAnyOrigin ( )
                          .AllowAnyMethod ( )
                          .AllowAnyHeader ( ) );
} );


// Add services to the container.
builder.Services.AddControllers ( );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ( );
builder.Services.AddSwaggerGen ( );

var app = builder.Build ( );


// Usar la política de CORS configurada
app.UseCors ( "AllowAllOrigins" );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ( ))
{
    app.UseSwagger ( );
    app.UseSwaggerUI ( );
}

app.UseHttpsRedirection ( );

app.UseAuthorization ( );

app.MapControllers ( );

app.Run ( );

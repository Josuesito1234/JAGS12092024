using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias
//Agrega el servicio de controladores al contenedor
builder.Services.AddControllers();
// Agrega el servicio para la exploracion de API de puntos finales
builder.Services.AddEndpointsApiExplorer();
//Agrega el serviscio para la generacion de Swagger
builder.Services.AddSwaggerGen();

//Configuracion para la autenticacion por cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Configura el nombre del parametro de URL para redireccionamiento no autorizado
        options.ReturnUrlParameter = "unauthorized";
        options.Events = new CookieAuthenticationEvents 
        { 
           OnRedirectToLogin = context =>
        };
    });
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

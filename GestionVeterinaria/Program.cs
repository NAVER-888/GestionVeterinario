using AccesoDatos.Operations;
using AccesoDatos.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se configura la autenticación para la API utilizando tokens JWT (Bearer Token)
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        // Se obtiene la sección "Jwt" del archivo appsettings.json
        var jwt = builder.Configuration.GetSection("Jwt");

        // Se establecen los parámetros de validación del token JWT
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Valida que el emisor (Issuer) coincida
            ValidateAudience = true, // Valida que la audiencia (Audience) coincida
            ValidateLifetime = true, // Valida que el token no esté expirado
            ValidateIssuerSigningKey = true, // Valida la firma del token

            ValidIssuer = jwt["Issuer"], // Emisor válido definido en configuración
            ValidAudience = jwt["Audience"], // Audiencia válida definida en configuración
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"])) // Clave secreta para validar la firma del token
        };
    });

// Se habilita el sistema de autorización para controlar el acceso a rutas o recursos
builder.Services.AddAuthorization();

// Registro de servicios personalizados para inyección de dependencias

// Servicio que contiene la lógica de negocio relacionada al usuario
builder.Services.AddScoped<UsuarioService>();

// DAO (Data Access Object) para acceder a los datos de la base de datos relacionados al usuario
builder.Services.AddScoped<UsuarioDAO>();

// Servicio encargado de generar tokens JWT
builder.Services.AddScoped<TokenService>();

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

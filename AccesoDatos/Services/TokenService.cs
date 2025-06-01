using AccesoDatos.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    // Servicio encargado de generar tokens JWT para autenticar usuarios
    public class TokenService
    {
        // Objeto de configuración para acceder a valores definidos en appsettings.json (como la clave del token, emisor, etc.)
        private readonly IConfiguration _config;

        // Constructor que recibe la configuración por inyección de dependencias
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        // Método que genera y retorna un token JWT para un usuario autenticado
        public string GenerarToken(Usuario usuario)
        {
            // Se obtiene la sección "Jwt" del archivo de configuración
            var jwtConfig = _config.GetSection("Jwt");

            // Se definen los claims, que son los datos que se incluirán dentro del token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.id_usuario.ToString()), // ID del usuario
                new Claim(ClaimTypes.Email, usuario.email),                          // Email del usuario
                new Claim("Nombre", usuario.nombre),                                  // Nombre personalizado
                new Claim(ClaimTypes.Role, usuario.rol)                               // Agregar el Rol
            };

            // Se crea la clave de seguridad usando la clave definida en la configuración (debe ser de al menos 256 bits)
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]));

            // Se definen las credenciales de firma con el algoritmo HMAC SHA256
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            // Se crea el token JWT especificando emisor, audiencia, claims, fecha de expiración y credenciales
            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],                     // Emisor del token
                audience: jwtConfig["Audience"],                 // Audiencia (quién puede usarlo)
                claims: claims,                                  // Claims definidos anteriormente
                expires: DateTime.UtcNow.AddMinutes(             // Tiempo de expiración del token
                    double.Parse(jwtConfig["ExpireMinutes"])),
                signingCredentials: credenciales                 // Firma del token
            );

            // Se serializa y devuelve el token como cadena
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

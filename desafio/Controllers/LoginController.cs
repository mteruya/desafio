using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using desafio.Configurations;
using desafio.Data.Interfaces;
using desafio.Data.Models;
using desafio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILogger _logger;

        private UsuarioService _usuarioService;


        public LoginController(IConfiguration configuration, UsuarioService usuarioService, ILoggerFactory loggerFactory)
        {
            _config = configuration;
            _usuarioService = usuarioService;
            _logger = loggerFactory.CreateLogger(typeof(LoginController));
        }
        [AllowAnonymous]
        [HttpPost]
        public object Post(
                    [FromBody]LoginModel usuario,
                    [FromServices]SigningConfigurations signingConfigurations,
                    [FromServices]TokenConfigurations tokenConfigurations)
        {
            _logger.LogInformation("Efetuando Login {usuario}!",usuario.Username);
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Username))
            {
                var usuarioBase = _usuarioService.ObterUsuario(usuario.Username, usuario.Password);
                credenciaisValidas = (usuarioBase!=null);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Username, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Username)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                _logger.LogInformation("Usuário: {usuario} autorizado!", usuario.Username);
                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };

            }
            else
            {
                _logger.LogInformation("Usuário, {usuario} não autorizado!", usuario.Username);
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
    //[AllowAnonymous]
    //[HttpPost]
    //public IActionResult CreateToken([FromBody]LoginModel login)
    //{
    //    IActionResult response = Unauthorized();
    //    var user = Authenticate(login);

    //    if (user != null)
    //    {
    //        var tokenString = BuildToken(user);
    //        response = Ok(new { token = tokenString });
    //    }

    //    return response;
    //}

    //private string BuildToken(Usuario usuario)
    //{
    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
    //        _config["Jwt:Issuer"],
    //        expires: DateTime.Now.AddMinutes(30),//tempo de expiração do token
    //        signingCredentials: creds //credenciais
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}


    //private Usuario Authenticate(LoginModel login)
    //{
    //    Usuario usuario= null;

    //    usuario = _usuarioService.ObterUsuario(login.Username, login.Password);
    //    return usuario;
    //}

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}

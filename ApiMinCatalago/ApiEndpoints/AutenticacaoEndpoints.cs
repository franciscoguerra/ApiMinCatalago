using ApiMinCatalago.Models;
using ApiMinCatalago.Services;
using Microsoft.AspNetCore.Authorization;
using sun.tools.tree;

namespace ApiMinCatalago.ApiEndpoints
{
    public static class AutenticacaoEndpoints
    {
        public static void  MapAutenticacaoEndpoint(this WebApplication app)
        {
            //endpoint para login
            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenServices tokenService) =>
            {
                if (userModel == null)
                {
                    return Results.BadRequest("Login Invalido");
                }
                if (userModel.UserName == "francisco" && userModel.Password == "senha12345")
                {
                    var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                                        app.Configuration["Jwt:Issuer"],
                                        app.Configuration["Jwt:Audience"],
                                        userModel);
                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login Invalido");
                }
            }).Produces(StatusCodes.Status400BadRequest)
                                   .Produces(StatusCodes.Status200OK)
                                   .WithTags("Autenticacao");
        }
    }
}

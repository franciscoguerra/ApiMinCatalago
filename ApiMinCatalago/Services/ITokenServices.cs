using ApiMinCatalago.Models;

namespace ApiMinCatalago.Services
{
    public interface ITokenServices
    {
        string GerarToken(string key, string issuer,string audience, UserModel user);
    }
}

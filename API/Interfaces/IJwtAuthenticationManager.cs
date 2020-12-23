namespace Escalator.API.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password, DBContext context);
        
    }
}
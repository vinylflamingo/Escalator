namespace Escalator.API
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
        
    }
}
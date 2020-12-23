namespace Escalator.API.Interfaces
{
    public interface IEmailService
    {
        string Send(string to, string subject, string html);
    }
}
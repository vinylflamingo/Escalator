using System.Threading.Tasks;

namespace Escalator.API.Interfaces
{
    public interface IEmailService
    {
        Task<string> Send(string to, string subject, string html);
    }
}
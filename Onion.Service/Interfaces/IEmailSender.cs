using System.Threading.Tasks;

namespace Onion.Service.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
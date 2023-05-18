using Miki.Services.Email.Messages;
using Miki.Services.Email.Models;

namespace Miki.Services.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}

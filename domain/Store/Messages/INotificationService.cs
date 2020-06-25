using System.Threading.Tasks;

namespace Store.Messages
{
    public interface INotificationService
    {
        void SendConfirmationCode(string cellPhone, int code);

        Task SendConfirmationCodeAsync(string cellPhone, int code);

        void StartProcess(Order order);

        Task StartProcessAsync(Order order);
    }
}

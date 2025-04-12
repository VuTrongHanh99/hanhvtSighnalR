using Microsoft.AspNetCore.SignalR;
namespace SignalR.Controllers
{
    public class SignalRHub : Hub
    {
        public async Task SendScreenStream(string screenData)
        {
            // Phát màn hình cho tất cả các client khác
            await Clients.Others.SendAsync("ReceiveScreenStream", screenData);
        }
    }
}

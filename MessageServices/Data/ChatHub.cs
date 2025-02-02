using Microsoft.AspNetCore.SignalR;

namespace MessageServices.Data
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Guid senderId,Guid receiverId,string message)
        {
            await Clients.User(receiverId.ToString()).SendAsync("ReceivedMessage", senderId,message);
        }
    }
}

using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs;

public class ChatHub : Hub
{
    public async Task NewMessage(string username, string message)
    {
        await Clients.All.SendAsync("messageReceived", username, message);
    }

    public async Task ChangeUserName(long usernameToChange)
    {
        int rnd = new Random().Next();
        string newUserName;
        if (rnd > 0.3)
        {
            newUserName = "Peti";
        }
        else if (rnd > 0.7)
        {
            newUserName = "Zsolti";
        }
        else
        {
            newUserName = "Bence";
        }
        await Clients.All.SendAsync("userNameChanged", usernameToChange, newUserName);
    }
}
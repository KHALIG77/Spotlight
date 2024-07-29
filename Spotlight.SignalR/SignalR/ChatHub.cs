using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Spotlight.SignalR.SignalR
{
    public class ChatHub:Hub
    {
      
            public async Task SendMessageToUser(string user, string message)
            {
                await Clients.User(user).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
            }

            public async Task SendMessageToGroup(string groupName, string message)
            {
                await Clients.Group(groupName).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
            }

            public async Task AddToGroup(string groupName)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            }

            public async Task RemoveFromGroup(string groupName)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            }

        }
    }

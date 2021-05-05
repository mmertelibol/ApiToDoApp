using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToDoApp.Hubs
{
    public class TodoHub : Hub
    {
        //public async Task SendMessageAsync(string message) //client in gönderdiği data bu parametreden gelecek
        //{
        //    await Clients.All.SendAsync("receiveMessage",message);

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignaIRChat.Hubs;
using SignaIRChat.Models;

namespace SignaIRChat.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<ChatHub> _chatHub;

        public HomeController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
    }
}

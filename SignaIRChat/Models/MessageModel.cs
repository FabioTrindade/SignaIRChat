using System;

namespace SignaIRChat.Models
{
    public class MessageModel
    {
        public Int64 destination { get; set; }
        public UserModel sender { get; set; }
        public string message { get; set; }
    }
}

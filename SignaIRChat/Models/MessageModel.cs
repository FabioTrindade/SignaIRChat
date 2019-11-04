using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignaIRChat.Models
{
    [Table("Message")]
    public class MessageModel
    {
        public int destination { get; set; }
        public UserModel sender { get; set; }
        public string message { get; set; }
    }
}

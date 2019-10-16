using System;

namespace SignaIRChat.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public Int64 key { get; set; }
        public DateTime dtConnection { get; set; }
        public bool ativo { get; set; }
    }
}

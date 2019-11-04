using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignaIRChat.Models
{
    [Table("User")]
    public class UserModel
    {
        public string name { get; set; }
        public int key { get; set; }
        public DateTime dtConnection { get; set; }
        public bool ativo { get; set; }
    }
}

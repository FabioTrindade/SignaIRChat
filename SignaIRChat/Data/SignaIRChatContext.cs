using Microsoft.EntityFrameworkCore;
using SignaIRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignaIRChat.Data
{
    public class SignaIRChatContext : DbContext
    {
        public SignaIRChatContext(DbContextOptions<SignaIRChatContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<MessageModel> Message { get; set; }

    }
}

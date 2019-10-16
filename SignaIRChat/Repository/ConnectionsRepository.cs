using Microsoft.EntityFrameworkCore;
using SignaIRChat.Data;
using SignaIRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignaIRChat.Repository
{
    public class ConnectionsRepository
    {
        private readonly SignaIRChatContext _context;

        public ConnectionsRepository(SignaIRChatContext context)
        {
            _context = context;
        }

        public void Add(UserModel user)
        {
            if (_context.User.Find(user.key) != null)
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }


        public string GetUserId(int id)
        {
            var user = _context.User
                        .Where(t => t.key == id)
                        .Select(t => t.name)
                        .AsNoTracking();

            return user.ToString();
        }


        public List<UserModel> GetAllUser()
        {
            var user = _context.User
                        .Where(t => t.ativo == true)
                        .AsNoTracking()
                        .ToList();

            return user;
        }
    }
}

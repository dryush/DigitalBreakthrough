using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;
using School.Data;
using School.Models;

namespace School.Hubs
{
    public class ChatHub : Hub
    {
        ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message, string discussion)
        {
            var us = _context.Users.FirstOrDefault( u => u.UserName == user);

            var nMes = new Message() {
                DiscussionId = int.Parse(discussion),
                Text = message,
                TimeAdd = DateTime.Now,
                UserId = us.Id
            };

            _context.Add(nMes);
            await _context.SaveChangesAsync();
            var mes = new MessageModel()
            {
                UserId = us.Id,
                Text = message,
                TimeAdd = DateTime.Now,
                FullName = us.FullName,
                Id = nMes.Id
            };

            await Clients.All.SendAsync("ReceiveMessage", mes);
        }
    }
}
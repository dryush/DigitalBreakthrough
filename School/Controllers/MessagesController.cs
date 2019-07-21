using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Messages/
        [HttpGet]
        public IEnumerable<MessageModel> Get(int discussionId)
        {
            return _context.Messages
                .Where(m => m.DiscussionId == discussionId)
                .Include(m => m.User)
                .Select(m => new MessageModel() {
                    Id = m.Id,
                    Text = m.Text,
                    TimeAdd = m.TimeAdd,
                    FullName = m.User.FullName
                });
        }

    }


}

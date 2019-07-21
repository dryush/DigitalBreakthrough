using School.Data;
using School.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Data
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public int UserId { get; set; }
        public int DiscussionId { get; set; }
        public DateTime TimeAdd { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Discussion Discussion { get; set; }
    }
}

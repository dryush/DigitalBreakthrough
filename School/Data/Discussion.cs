using School.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Data.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public List<Voicing> Voicinigs { get; set; } = new List<Voicing>();
        public DiscussionStatus Status
        {
            get
            {   if (EndDate < DateTime.Now)
                    return DiscussionStatus.CLOSE;
                if (EndDate < DateTime.Now.AddDays(2))
                    return DiscussionStatus.FIRE;
                else
                    return DiscussionStatus.PROCESS;
            }
        }

        public SchoolClass SchoolClass { get; set; }
        public int SchoolClassId { get; set; }
    }



    public enum DiscussionStatus : int
    {
        FIRE = 1,
        PROCESS,
        CLOSE,
    }

    public class Voicing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
         public List<VoicingOption> Options { get; set; } = new List<VoicingOption>();
        
        public int DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
    }

    public class VoicingOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Voice> Voices { get; set; } = new List<Voice>();

        public int VoicingId { get; set; }
        public Voicing Voicing {get;set;}
    }

    public class Voice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }

        public VoicingOption Option { get; set; }
    }


    public class SchoolClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual List<AppUser> Parents { get; set; } = new List<AppUser>();

        public int TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }

        public List<Discussion> Discussions { get; set; }
    }

   
}

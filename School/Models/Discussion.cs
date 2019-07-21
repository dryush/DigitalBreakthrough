
using School.Data.Models;
using System;
using System.Collections.Generic;

namespace School.Models
{

    public class MessageModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime TimeAdd { get; set; }
        public string FullName { get; set; }
    }

    public class DiscussionModel
    {
        public int SchoolClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DiscussionStatus Status { get; set; }
        public List<VoicingModel> Voicinigs { get; set; } = new List<VoicingModel>();
        public int SchoolClassParentsCount { get; set; }

    }

    public class VoicingModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool IsVoited { get; set; }

        public bool IsShowVoices { get; set; }
        public string SchoolClassId { get; set; }

        public int VoutedCount { get; set; }
        public List<VoicingOptionModel> Options { get; set; } = new List<VoicingOptionModel>();
    }

    public class VoiceModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string OptionId { get; set; }
        public string OptionName { get; set; }
    }

    public class VoicingOptionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VoutedCount { get; set; }
    }
    public class StringModel
    {
        public string Value { get; set; }
        public DateTime DateEnd { get; set; }
    }
    public class IdModel
    {
        public int Id { get; set; }
    }

    public class ParentVoiceModel
    {
        public string optionId { get; set; }
        public int discId { get; set; }
        public string classId { get; set; }
    }
}
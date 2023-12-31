﻿namespace LexiconLMS.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //ForeignKey
        public Guid CourseId { get; set; }

        //Navigation Property
        public Course Course { get; set; } = default!;
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}
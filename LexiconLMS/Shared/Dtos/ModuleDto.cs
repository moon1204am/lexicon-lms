﻿namespace LexiconLMS.Shared.Dtos
{
    public class ModuleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        ////ForeignKey
        //public Guid CourseId { get; set; }

        ////Navigation Property
        //public CourseDto Course { get; set; }
        public ICollection<ActivityDto> Activities { get; set; } = new List<ActivityDto>();

    }
}
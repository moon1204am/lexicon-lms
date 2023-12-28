﻿namespace LexiconLMS.Shared.Dtos
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //Foreign key

        public Guid ModuleId { get; set; }

        public Guid ActivityTypeId { get; set; }

        //Navigation Properties

        public Module Module { get; set; } = new Module();

        public ActivityTypeDto Type { get; set; } = new ActivityTypeDto();


    }
}
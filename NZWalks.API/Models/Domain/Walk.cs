﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKms { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

        public Guid RegionId { get; set; }
        public Region Region { get; set; }
    }
}

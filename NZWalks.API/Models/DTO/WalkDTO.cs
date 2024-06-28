using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKms { get; set; }
        public string? WalkImgUrl { get; set; }

        public DifficultyDTO DifficultyDTO { get; set; }

        public RegionDTO RegionDTO { get; set; }
    }
}

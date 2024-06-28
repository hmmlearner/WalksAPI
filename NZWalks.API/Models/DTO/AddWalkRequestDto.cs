using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKms { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}

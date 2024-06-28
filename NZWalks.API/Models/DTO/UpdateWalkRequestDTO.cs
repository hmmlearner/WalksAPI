namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKms { get; set; }
        public string? WalkImgUrl { get; set; }
    }
}

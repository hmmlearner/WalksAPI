using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalk(Walk walk);

        Task<Walk?> GetWalkById(Guid id);

        Task<List<Walk>> GetAllWalks();

        Task<Walk?> UpdateWalk(Guid id, Walk walk);

        Task<Walk?> DeleteWalk(Guid id);

    }
}

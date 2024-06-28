using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRespository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?>GetByIdAsync(Guid id);

        Task<Region> CreateAsyncRegion(Region region);

        Task<Region?> UpdateAsyncRegion(Guid id, Region region);

        Task<Region?> DeleteAsyncRegion(Guid id);
    }
}

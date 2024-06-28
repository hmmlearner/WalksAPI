using NZWalks.API.Data;
using NZWalks.API.Models;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _nzWalksDbContext;

        public WalkRepository(NZWalksDbContext nzWalksDbContext) 
        {
            _nzWalksDbContext = nzWalksDbContext;
        }
        public async Task<Walk> CreateWalk(Walk walk)
        {
            await _nzWalksDbContext.Walks.AddAsync(walk);
            await _nzWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks()
        {
            return await _nzWalksDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync<Walk>();
        }

        public async Task<Walk?> GetWalkById(Guid id)
        {
            return await _nzWalksDbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync<Walk>(x => x.Id == id);

        }

        public async Task<Walk?> UpdateWalk(Guid id, Walk walk)
        {
            var walkUpdate = await _nzWalksDbContext.Walks.FirstOrDefaultAsync<Walk>(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }
            walkUpdate.Name = walk.Name;
            walkUpdate.Description = walk.Description;
            walkUpdate.LengthInKms = walk.LengthInKms;
            walkUpdate.WalkImgUrl  = walk.WalkImgUrl;
            walkUpdate.DifficultyId= walk.DifficultyId;
            walkUpdate.RegionId= walk.RegionId;

            await _nzWalksDbContext.SaveChangesAsync();
            return walkUpdate;
        }

        public async Task<Walk?> DeleteWalk(Guid id)
        {
            var walk = await _nzWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walk == null)
            {
                return null;
            }
             _nzWalksDbContext.Walks.Remove(walk);
            await _nzWalksDbContext.SaveChangesAsync();

            return walk;
        }
    }
}

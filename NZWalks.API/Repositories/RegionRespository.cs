using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class RegionRespository : IRegionRespository
    {
        private readonly NZWalksDbContext _nzWalksDbContext;

        public RegionRespository(NZWalksDbContext nZWalksDbContext)
        {
            _nzWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> CreateAsyncRegion(Region region)
        {
            await _nzWalksDbContext.Regions.AddAsync(region);
            await _nzWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsyncRegion(Guid id)
        {
            var regionVM = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(options => options.Id == id);
            if (regionVM == null)
            { 
                return null;
            }

            _nzWalksDbContext.Regions.Remove(regionVM);
            await _nzWalksDbContext.SaveChangesAsync();
            return regionVM;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            var regions = await _nzWalksDbContext.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
        }

        public async Task<Region?> UpdateAsyncRegion(Guid id, Region region)
        {
            var domainRegion = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            if (domainRegion == null)
            {
                return null;
            }
            domainRegion.Code = region.Code;
            domainRegion.Name = region.Name;
            domainRegion.RegionImgUrl = region.RegionImgUrl;
            await _nzWalksDbContext.SaveChangesAsync();

            return domainRegion;
        }
    }
}

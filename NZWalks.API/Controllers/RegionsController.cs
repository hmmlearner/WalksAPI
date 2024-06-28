using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _nzWalksDbContext;
        private readonly IRegionRespository _regionRespository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext nZWalksDbContext, IRegionRespository regionRespository, IMapper mapper) {
            _nzWalksDbContext = nZWalksDbContext;
            _regionRespository = regionRespository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRespository.GetAllAsync(); //await _nzWalksDbContext.Regions.ToListAsync();
            //var regionDTOs = new List<RegionDTO>();
            //foreach (var region in regions)
            //{
               
            //    //regionDTOs.Add(new RegionDTO()
            //    //{
            //    //    Id = region.Id,
            //    //    Code = region.Code,
            //    //    Name = region.Name,
            //    //    RegionImgUrl = region.RegionImgUrl
            //    //});
            //}
            var regionDTOs = _mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionDTOs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromBody] Guid id)
        {
            var region = await _regionRespository.GetByIdAsync(id); //await _nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            //var regionDTO = new RegionDTO();
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImgUrl = region.RegionImgUrl
            //};

            return Ok(_mapper.Map<RegionDTO>(region));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDTO addRegionDTO)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionDTO);
            //new Region
            //{
            //    Code = addRegionDTO.Code,
            //    Name = addRegionDTO.Name,
            //    RegionImgUrl = addRegionDTO.RegionImgUrl
            //};
            //await _nzWalksDbContext.Regions.AddAsync(regionDomainModel);
            //await _nzWalksDbContext.SaveChangesAsync();
            regionDomainModel = await _regionRespository.CreateAsyncRegion(regionDomainModel);
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);
            //    new RegionDTO()
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImgUrl = regionDomainModel.RegionImgUrl
            //};

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);// cannot send domain model to need to map it to DTO
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            //var domainRegion = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            //if (domainRegion == null)
            //{
            //    return BadRequest();
            //}
            //domainRegion.Code = updateRegionDTO.Code;
            //domainRegion.Name = updateRegionDTO.Name;
            //domainRegion.RegionImgUrl = updateRegionDTO.RegionImgUrl;
            //await _nzWalksDbContext.SaveChangesAsync();

            var domainRegion = _mapper.Map<Region>(updateRegionDTO);

            domainRegion = await _regionRespository.UpdateAsyncRegion(id, domainRegion);

            var regionDTO = _mapper.Map<RegionDTO>(domainRegion);
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            //var regionVM = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(options => options.Id == id);

            //_nzWalksDbContext.Regions.Remove(regionVM);
            //await _nzWalksDbContext.SaveChangesAsync();
            var regionVM = await _regionRespository.DeleteAsyncRegion(id);
            if (regionVM == null)
            {
                return BadRequest();
            }

            var regionDTO = _mapper.Map<RegionDTO>(regionVM);

            return Ok(regionDTO);

        }

    }
}

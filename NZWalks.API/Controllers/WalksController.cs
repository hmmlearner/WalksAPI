using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //  /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        //create walk
        public async Task<IActionResult> CreateWalk([FromBody]AddWalkRequestDto AddWalkDto)
        {
            var walkDM = _mapper.Map<Walk>(AddWalkDto);
            walkDM = await _walkRepository.CreateWalk(walkDM);
            var walkDTO = _mapper.Map<WalkDTO>(walkDM);

            return CreatedAtAction(nameof(GetWalkById), new { id = walkDTO.Id }, walkDTO);
        }

        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkVM = await _walkRepository.GetWalkById(id);
            return Ok(_mapper.Map<WalkDTO>(walkVM));
        }

        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await _walkRepository.GetAllWalks();
            var walksDTO = _mapper.Map<List<WalkDTO>>(walks);
            return Ok(walksDTO);
        }

        public async Task<IActionResult> UpdateWalk([FromBody] UpdateWalkRequestDTO UpdateWalkRequest, [FromRoute]Guid id)
        {
            var walk = _mapper.Map<Walk>(UpdateWalkRequest);
            walk = await _walkRepository.UpdateWalk(id, walk);
            if(walk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walkVM = _walkRepository.DeleteWalk(id);
            if(walkVM == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<WalkDTO>(walkVM));
        }

    }
}

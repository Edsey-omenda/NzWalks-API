using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Models.Domain;
using NzWalks.Models.DTOs;
using NzWalks.Repositories;

namespace NzWalks.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //CREATE
        //POST: /api/walks/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //Get Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();

            //Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        //Get a single walk
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetByIdAsync(id);

            if(walksDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDTO>(walksDomainModel));
        }

        //Update a walk
        //PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDTO updateWalkDTO)
        {
            //Map DTO to Domain Model
            var walkDomainModel =  mapper.Map<Walk>(updateWalkDTO);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound(walkDomainModel);
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //Delete a walk
        //DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDTO>(deletedWalkModel));
        }
    }
}

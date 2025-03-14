using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.CustomActionFilters;
using NzWalks.Data;
using NzWalks.Models.Domain;
using NzWalks.Models.DTOs;
using NzWalks.Repositories;

namespace NzWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private NzWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }
        //Get All Regions
        //Get: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database - in form of domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            //map domain models to DTOs
            var regionsDto = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain) 
            {
                regionsDto.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }
            //return DTOs
            return Ok(regionsDto);
        }

        //Get Region By Id
        //Get: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get region from database - in form of domain models
            //var regionDomain = await dbContext.Regions.FindAsync(id);
            var regionDomain = await regionRepository.GetByIdAsync(id);


            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map to regionDto
            var regionDto = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            //return Dto back to client
            return Ok(regionDto);
        }

        //Post to create new region
        //Post: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDTO addRegionDto) 
        {
                //Covert the Dto to domain model
                var regionDomainModel = new Region
                {
                    Name = addRegionDto.Name,
                    Code = addRegionDto.Code,
                    RegionImageUrl = addRegionDto.RegionImageUrl,
                };

                //Use domain model to create a new region
                //await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //Map domain model back to Dto
                var regionDto = new RegionDTO
                {
                    Id = regionDomainModel.Id,
                    Name = regionDomainModel.Name,
                    Code = regionDomainModel.Code,
                    RegionImageUrl = regionDomainModel.RegionImageUrl,
                };

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            
        }

        //Update existing region
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDto)
        {
    
                //Map Dto to Domain Model
                var regionDomainModel = new Region
                {
                    Code = updateRegionDto.Code,
                    Name = updateRegionDto.Name,
                    RegionImageUrl = updateRegionDto.RegionImageUrl
                };
                //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //Map domain model back to Dto
                var regionDto = new RegionDTO
                {
                    Id = regionDomainModel.Id,
                    Name = regionDomainModel.Name,
                    Code = regionDomainModel.Code,
                    RegionImageUrl = regionDomainModel.RegionImageUrl,
                };

                return Ok(regionDto);
           
        }

        //Delete a region
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id) 
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //Map domain model back to Dto
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

    }
}

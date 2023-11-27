using Microsoft.AspNetCore.Mvc;

using Digix.Application.Dtos;
using Digix.Application.Services;

namespace Digix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpPost]
        public async Task<ActionResult<FamilyDto>> CreateNewFamily([FromBody] CreateFamilyDto newFamilyDto)
        {
            try
            {
                var familyDto = await _familyService.CreateNewFamily(newFamilyDto);

                if(familyDto == null) {
                    return BadRequest();
                }

                return Created("",familyDto);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RunFamilyAnalysis/{familyId:int}")]
        public async Task<ActionResult<FamilyAnalysisDto>> RunFamilyAnalysis(int familyId)
        {
            try
            {
                var familyAnalysis = await _familyService.RunFamilyAnalysis(familyId);
                return Created("", familyAnalysis);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFamilyAnalysis/{familyAnalysisId:int}")]
        public async Task<ActionResult<FamilyAnalysisDto>> GetFamilyAnalysis(int familyAnalysisId)
        {
            try
            {
                var familyAnalysis = await _familyService.GetFamilyAnalysis(familyAnalysisId);
                return Ok(familyAnalysis);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [HttpGet("GetListOfFamiliesByScore")]
        public async Task<ActionResult> GetListOfFamiliesByScore([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _familyService.GetListOfFamiliesByScore(page, pageSize);

            return Ok(response);
        }

    }
}

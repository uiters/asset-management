using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DepreciationController : GWebsiteControllerBase
    {
        private readonly IDepreciationAppService depreciationAppService;

        public DepreciationController(IDepreciationAppService depreciationAppService)
        {
            this.depreciationAppService = depreciationAppService;
        }

        [HttpGet]
        public PagedResultDto<DepreciationDto> GetDepreciationsByFilter(DepreciationFilter depreciationFilter)
        {
            return depreciationAppService.GetDepreciations(depreciationFilter);
        }

        [HttpGet]
        public DepreciationInput GetDepreciationForEdit(int id)
        {
            return depreciationAppService.GetDepreciationForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDepreciation([FromBody] DepreciationInput input)
        {
            depreciationAppService.CreateOrEditDepreciation(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDepreciation(int id)
        {
            depreciationAppService.DeleteDepreciation(id);
        }

        [HttpGet]
        public DepreciationForViewDto GetDepreciationForView(int id)
        {
            return depreciationAppService.GetDepreciationForView(id);
        }
    }
}
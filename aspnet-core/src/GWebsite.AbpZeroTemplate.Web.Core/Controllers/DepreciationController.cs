using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DepreciationController : GWebsiteControllerBase
    {
        private readonly IDepreciationAppService _DepreciationAppService;

        public DepreciationController(IDepreciationAppService DepreciationAppService)
        {
            _DepreciationAppService = DepreciationAppService;
        }

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }

        [HttpGet]
        public async Task<ListResultDto<DepreciationDto>> GetDepreciations()
        {
            return await _DepreciationAppService.GetDepreciationsAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<DepreciationListDto>> GetDepreciationsByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _DepreciationAppService.GetDepreciationsAsync(new GetDepreciationInput() { Name = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet]
        public string DemoWebApi()
        {
            return "Abcdezz";
        }

        [HttpGet]
        public async Task<GetDepreciationOutput> GetDepreciationForEdit(int id)
        {
            return await _DepreciationAppService.GetDepreciationForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public async Task<DepreciationDto> CreateDepreciation([FromBody] CreateDepreciationInput input)
        {
            return await _DepreciationAppService.CreateDepreciationAsync(input);
        }

        [HttpPut]
        public async Task<DepreciationDto> UpdateDepreciation([FromBody] UpdateDepreciationInput input)
        {
            return await _DepreciationAppService.UpdateDepreciationAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDepreciation(int id)
        {
            await _DepreciationAppService.DeleteDepreciationAsync(new EntityDto<int>() { Id = id });
        }
    }
}

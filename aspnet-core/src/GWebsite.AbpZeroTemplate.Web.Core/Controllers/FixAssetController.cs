using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FixAssets.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FixAssetController : GWebsiteControllerBase
    {
        private readonly IFixAssetAppService _FixAssetAppService;

        public FixAssetController(IFixAssetAppService FixAssetAppService)
        {
            _FixAssetAppService = FixAssetAppService;
        }

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }

        [HttpGet]
        public async Task<ListResultDto<FixAssetDto>> GetFixAssets()
        {
            return await _FixAssetAppService.GetFixAssetsAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<FixAssetListDto>> GetFixAssetsByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _FixAssetAppService.GetFixAssetsAsync(new GetFixAssetInput() { Name = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet]
        public string DemoWebApi()
        {
            return "Abcdezz";
        }

        [HttpGet]
        public async Task<GetFixAssetOutput> GetFixAssetForEdit(int id)
        {
            return await _FixAssetAppService.GetFixAssetForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public async Task<FixAssetDto> CreateFixAsset([FromBody] CreateFixAssetInput input)
        {
            return await _FixAssetAppService.CreateFixAssetAsync(input);
        }

        [HttpPut]
        public async Task<FixAssetDto> UpdateFixAsset([FromBody] UpdateFixAssetInput input)
        {
            return await _FixAssetAppService.UpdateFixAssetAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteFixAsset(int id)
        {
            await _FixAssetAppService.DeleteFixAssetAsync(new EntityDto<int>() { Id = id });
        }
    }
}

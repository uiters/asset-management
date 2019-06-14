using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset;
using GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset.Dto;
using Microsoft.AspNetCore.Mvc;
namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EvictionAssetController : GWebsiteControllerBase
    {
        private readonly IEvictionAsset appService;

        public EvictionAssetController(IEvictionAsset appService)
        {
            this.appService = appService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<EvictionAssetDto> GetEvictionAssets() => appService.GetEvictionAssets();

        [HttpGet]
        public PagedResultDto<EvictionAssetDto> GetEvictionAssetsByFilter(EvictionAssetFilter filter) => appService.GetEvictionAssetsByFilter(filter);

        [HttpGet]
        public ListResultDto<EvictionAssetDto> GetEvictionAssetByCode(string code) => appService.GetEvictionAssetByCode(code);

        [HttpGet]
        public EvictionAssetDto GetEvictionAssetForEdit(int id) => appService.GetEvictionAssetForEdit(id);
        #endregion

        #region POST
        [HttpPost]
        public EvictionAssetDto CreateEvictionAsset([FromBody] EvictionAssetDto input) => appService.CreateEvictionAsset(input);

        #endregion

        #region Put

        [HttpPut]
        public EvictionAssetDto UpdateAsset([FromBody] EvictionAssetDto input) => appService.UpdateEvictionAsset(input);
        #endregion

        #region Delete

        [HttpDelete]
        public void DeleteEvictionAsset(int id) => appService.DeleteEvictionAsset(id);

        #endregion
    }
}

using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetController : GWebsiteControllerBase
    {
        private readonly IAssetAppService appService;

        public AssetController(IAssetAppService assetAppService)
        {
            this.appService = assetAppService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<AssetDto> GetAssets() => appService.GetAssets();

        [HttpGet]
        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter filter) => appService.GetAssetsByFilter(filter);

        [HttpGet]
        public AssetDto GetAssetByCode(string code) => appService.GetAssetByCode(code);

        [HttpGet]
        public AssetDto GetAssetForEdit(int id) => appService.GetAssetForEdit(id);
        #endregion

        #region POST
        [HttpPost]
        public AssetDto CreateAsset([FromBody] AssetInput input) => appService.CreateAsset(input);
        
        #endregion

        #region Put

        [HttpPut]
        public AssetDto UpdateAsset([FromBody] AssetInput input) => appService.UpdateAsset(input);
        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public void DeleteAsset(int id) => appService.DeleteAsset(id);

        #endregion
    }
}

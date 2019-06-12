using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset;
using GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]

    public class LiquidationAssetController : GWebsiteControllerBase
    {
        private readonly ILiquidationAsset appService;

        public LiquidationAssetController(ILiquidationAsset assetAppService)
        {
            appService = assetAppService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<LiquidationAssetDto> GetLiquidationAssets()
        {
            return appService.GetLiquidationAssets();
        }

        [HttpGet]
        public PagedResultDto<LiquidationAssetDto> GetLiquidationAssetsByFilter(LiquidationAssetFilter filter)
        {
            return appService.GetLiquidationAssetsByFilter(filter);
        }

        [HttpGet]
        public ListResultDto<LiquidationAssetDto> GetLiquidationAssetByCode(string code)
        {
            return appService.GetLiquidationAssetByCode(code);
        }

        [HttpGet]
        public LiquidationAssetDto GetLiquidationAssetForEdit(int id)
        {
            return appService.GetLiquidationAssetForEdit(id);
        }
        #endregion

        #region POST
        [HttpPost]
        public LiquidationAssetDto CreateLiquidationAsset([FromBody] LiquidationAssetDto input)
        {
            return appService.CreateLiquidationAsset(input);
        }

        #endregion

        #region Put

        [HttpPut]
        public LiquidationAssetDto UpdateLiquidationAsset([FromBody] LiquidationAssetDto input)
        {
            return appService.UpdateLiquidationAsset(input);
        }
        #endregion

        #region Delete

        [HttpDelete]
        public void DeleteLiquidationAsset(int id)
        {
            appService.DeleteLiquidationAsset(id);
        }

        #endregion
    }
}

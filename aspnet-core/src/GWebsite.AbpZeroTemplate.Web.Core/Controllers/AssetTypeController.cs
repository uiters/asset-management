using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetTypeController : GWebsiteControllerBase
    {
        private readonly IAssetTypeAppService appService;

        public AssetTypeController(IAssetTypeAppService appService)
        {
            this.appService = appService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<AssetTypeDto> GetAssetTypes() => appService.GetAssetTypes();

        [HttpGet]
        public PagedResultDto<AssetTypeDto> GetAssetTypesByFilter(AssetTypeFilter filter) => appService.GetAssetTypesByFilter(filter);

        [HttpGet]
        public AssetTypeDto GetAssetTypeByCode(string code) => appService.GetAssetTypeByCode(code);

        [HttpGet]
        public AssetTypeDto GetAssetTypeForEdit(int id) => appService.GetAssetTypeForEdit(id);

        [HttpGet]
        public AssetTypeCombobox GetAssetTypeCombobox(int? id) => appService.GetAssetTypeCombobox(id);
        #endregion

        #region POST
        [HttpPost]
        public AssetTypeDto CreateAssetType([FromBody] AssetTypeInput input) => appService.CreateAssetType(input);

        #endregion

        #region Put

        [HttpPut]
        public AssetTypeDto UpdateAssetType([FromBody] AssetTypeInput input) => appService.UpdateAssetType(input);
        #endregion

        #region Delete

        [HttpDelete]
        public void DeleteAssetType(int id) => appService.DeleteAssetType(id);

        #endregion
    }
}

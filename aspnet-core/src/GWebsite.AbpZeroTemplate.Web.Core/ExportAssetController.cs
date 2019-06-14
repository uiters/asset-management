using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Controllers;
using GWebsite.AbpZeroTemplate.Application.Share.ExportAsset;
using GWebsite.AbpZeroTemplate.Application.Share.ExportAsset.Dto;
using Microsoft.AspNetCore.Mvc;


namespace GWebsite.AbpZeroTemplate.Application
{
    [Route("api/[controller]/[action]")]
    public class ExportAssetController : GWebsiteControllerBase
    {
        private readonly IExportAsset appService;

        public ExportAssetController(IExportAsset AppService)
        {
            appService = AppService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<ExportAssetDto> GetExportAssets()
        {
            return appService.GetExportAssets();
        }

        [HttpGet]
        public PagedResultDto<ExportAssetDto> GetExportAssetsByFilter(ExportAssetFilter filter)
        {
            return appService.GetExportAssetsByFilter(filter);
        }

        [HttpGet]
        public ListResultDto<ExportAssetDto> GetExportAssetByCode(string code)
        {
            return appService.GetExportAssetByCode(code);
        }

        [HttpGet]
        public ExportAssetDto GetExportAssetForEdit(int id)
        {
            return appService.GetExportAssetForEdit(id);
        }

        #endregion

        #region POST
        [HttpPost]
        public ExportAssetDto CreateExportAsset([FromBody] ExportAssetDto input)
        {
            return appService.CreateExportAsset(input);
        }

        #endregion

        #region Put

        [HttpPut]
        public ExportAssetDto UpdateExportAsset([FromBody] ExportAssetDto input)
        {
            return appService.UpdateExportAsset(input);
        }
        #endregion

        #region Delete

        [HttpDelete]
        public void DeleteExportAsset(int id)
        {
            appService.DeleteExportAsset(id);
        }

        #endregion
    }
}

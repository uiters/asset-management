using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Controllers;
using GWebsite.AbpZeroTemplate.Application.Share.TransferAsset;
using GWebsite.AbpZeroTemplate.Application.Share.TransferAsset.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application
{
    [Route("api/[controller]/[action]")]
    public class TransferAssetController : GWebsiteControllerBase
    {
        private readonly ITransferAsset appService;

        public TransferAssetController(ITransferAsset appService)
        {
            this.appService = appService;
        }

        #region GET
        [HttpGet]
        public ListResultDto<TransferAssetDto> GetTransferAssets()
        {
            return appService.GetTransferAssets();
        }

        [HttpGet]
        public PagedResultDto<TransferAssetDto> GetTransferAssetsByFilter(TransferAssetFilter filter)
        {
            return appService.GetTransferAssetsByFilter(filter);
        }

        [HttpGet]
        public ListResultDto<TransferAssetDto> GetTransferAssetByCode(string code)
        {
            return appService.GetTransferAssetByCode(code);
        }

        [HttpGet]
        public TransferAssetDto GetTransferAssetForEdit(int id)
        {
            return appService.GetTransferAssetForEdit(id);
        }
        #endregion

        #region POST
        [HttpPost]
        public TransferAssetDto CreateTransferAsset([FromBody] TransferAssetDto input)
        {
            return appService.CreateTransferAsset(input);
        }

        #endregion

        #region Put

        [HttpPut]
        public TransferAssetDto UpdateTransferAsset([FromBody] TransferAssetDto input)
        {
            return appService.UpdateTransferAsset(input);
        }
        #endregion

        #region Delete

        [HttpDelete]
        public void DeleteTransferAsset(int id)
        {
            appService.DeleteTransferAsset(id);
        }

        #endregion
    }
}

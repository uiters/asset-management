using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GroupAssets;
using GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GroupAssetController : GWebsiteControllerBase
    {
        private readonly IGroupAssetAppService appService;

        public GroupAssetController(IGroupAssetAppService appService)
        {
            this.appService = appService;
        }


        #region GET
        [HttpGet]
        public ListResultDto<GroupAssetDto> GetGroupAssets() => appService.GetGroupAssets();
    

        [HttpGet]
        public PagedResultDto<GroupAssetDto> GetAssetsByFilter(GroupAssetFilter filter) => appService.GetGroupAssetsByFilter(filter);

        [HttpGet]
        public GroupAssetDto GetGroupAssetByCode(string code) => appService.GetGroupAssetByCode(code);

        [HttpGet]
        public GroupAssetDto GetGroupAssetForEdit(int id) => appService.GetGroupAssetForEdit(id);

        [HttpGet]
        public GroupAssetCombobox GetAssetTypeCombobox(int? id) => appService.GetGroupAssetCombobox(id);
        #endregion

        #region POST
        [HttpPost]
        public GroupAssetDto CreateGroupAsset([FromBody] GroupAssetInput input) => appService.CreateGroupAsset(input);

        #endregion

        #region Put

        [HttpPut]
        public GroupAssetDto UpdateGroupAsset([FromBody] GroupAssetInput input) => appService.UpdateGroupAsset(input);
        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public void DeleteGroupAsset(int id) => appService.DeleteGroupAsset(id);

        #endregion
    }
}

using Abp.AutoMapper;
using GSoft.AbpZeroTemplate.Authorization.Roles.Dto;
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}
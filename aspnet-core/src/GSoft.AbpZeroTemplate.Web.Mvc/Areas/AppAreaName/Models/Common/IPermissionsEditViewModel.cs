using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Authorization.Permissions.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}
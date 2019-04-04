using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Authorization.Permissions.Dto;

namespace GSoft.AbpZeroTemplate.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
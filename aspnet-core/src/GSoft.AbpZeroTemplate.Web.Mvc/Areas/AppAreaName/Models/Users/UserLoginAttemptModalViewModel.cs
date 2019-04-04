using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Authorization.Users.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}
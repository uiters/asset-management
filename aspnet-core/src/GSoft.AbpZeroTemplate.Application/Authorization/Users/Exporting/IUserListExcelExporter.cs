using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Authorization.Users.Dto;
using GSoft.AbpZeroTemplate.Dto;

namespace GSoft.AbpZeroTemplate.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}
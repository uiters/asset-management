using GSoft.AbpZeroTemplate.Dto;

namespace GSoft.AbpZeroTemplate.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}
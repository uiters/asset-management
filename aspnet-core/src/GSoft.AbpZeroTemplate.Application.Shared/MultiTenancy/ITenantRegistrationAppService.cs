using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Editions.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy.Dto;

namespace GSoft.AbpZeroTemplate.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}
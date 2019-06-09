using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Units.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units
{
    public interface IUnitAppService
    {
        Task<ListResultDto<UnitDto>> GetUnitsAsync();

        Task<PagedResultDto<UnitListDto>> GetUnitsAsync(GetUnitInput input);

        Task<GetUnitOutput> GetUnitForEditAsync(NullableIdDto input);

        Task<UnitDto> CreateUnitAsync(CreateUnitInput input);

        Task<UnitDto> UpdateUnitAsync(UpdateUnitInput input);

        Task DeleteUnitAsync(EntityDto<int> input);
        UnitCombobox GetUnitCombobox(int? id);
    }
}

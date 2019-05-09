using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Depreciations
{
    public interface IDepreciationAppService
    {
        void CreateOrEditDepreciation(DepreciationInput customerInput);
        DepreciationInput GetDepreciationForEdit(int id);
        void DeleteDepreciation(int id);
        PagedResultDto<DepreciationDto> GetDepreciations(DepreciationFilter input);
        DepreciationForViewDto GetDepreciationForView(int id);
    }
}

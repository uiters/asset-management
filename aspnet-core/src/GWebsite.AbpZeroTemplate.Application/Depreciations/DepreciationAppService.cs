using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Depreciations
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Depreciation)]
    public class DepreciationAppService : GWebsiteAppServiceBase, IDepreciationAppService
    {
        private readonly IRepository<Depreciation, int> _menuRepository;

        public DepreciationAppService(IRepository<Depreciation, int> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ListResultDto<DepreciationDto>> GetDepreciationsAsync()
        {

            var items = await _menuRepository.GetAllListAsync();

            return new ListResultDto<DepreciationDto>(
                items.Select(item => ObjectMapper.Map<DepreciationDto>(item)).ToList());

        }

        public async Task<PagedResultDto<DepreciationListDto>> GetDepreciationsAsync(GetDepreciationInput input)
        {
            var query = _menuRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<DepreciationListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DepreciationListDto>(item)).ToList());
        }

        public async Task<GetDepreciationOutput> GetDepreciationForEditAsync(NullableIdDto input)
        {
            Depreciation Depreciation = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                Depreciation = await _menuRepository.GetAsync(input.Id.Value);
            }
            var output = new GetDepreciationOutput();

            output.Depreciation = Depreciation != null
                ? ObjectMapper.Map<DepreciationDto>(Depreciation)
                : new DepreciationDto();

            var parentMenuId = output.Depreciation.ParentId ?? 0;
            output.Depreciations = await _menuRepository.GetAll()
                .Where(m => m.Status)
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name) { IsSelected = parentMenuId == c.Id })
                .ToListAsync();

            return output;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Depreciation_Create)]
        public async Task<DepreciationDto> CreateDepreciationAsync(CreateDepreciationInput input)
        {
            var entity = ObjectMapper.Map<Depreciation>(input);
            entity = await _menuRepository.InsertAsync(entity);
            return ObjectMapper.Map<DepreciationDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Depreciation_Edit)]
        public async Task<DepreciationDto> UpdateDepreciationAsync(UpdateDepreciationInput input)
        {
            var entity = await _menuRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _menuRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<DepreciationDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Depreciation_Delete)]
        public async Task DeleteDepreciationAsync(EntityDto<int> input)
        {
            var entity = await _menuRepository.GetAsync(input.Id);
            //Tạm thời hiểu status là field dể check record đó có dc xóa hay ko
            //Để biết thêm chi tiết liên hệ với Thức :D
            entity.Status = false;
            entity = await _menuRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}

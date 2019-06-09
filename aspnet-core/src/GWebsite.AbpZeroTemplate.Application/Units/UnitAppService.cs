using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.Units;
using GWebsite.AbpZeroTemplate.Application.Share.Units.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Units
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Unit)]
    public class UnitAppService : GWebsiteAppServiceBase, IUnitAppService
    {
        private readonly IRepository<Unit, int> _menuRepository;

        public UnitAppService(IRepository<Unit, int> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ListResultDto<UnitDto>> GetUnitsAsync()
        {

            var items = await _menuRepository.GetAllListAsync();

            return new ListResultDto<UnitDto>(
                items.Select(item => ObjectMapper.Map<UnitDto>(item)).ToList());

        }
        public UnitCombobox GetUnitCombobox(int? id)
        {
            int idSelect = id ?? 1;
            System.Collections.Generic.List<ComboboxItemDto> Units = _menuRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(Unit => new ComboboxItemDto(Unit.Id.ToString(), Unit.UnitName) { IsSelected = Unit.Id == idSelect })
                .ToList();

            UnitCombobox UnitCombobox = new UnitCombobox
            {
                Units = Units
            };

            return UnitCombobox;
        }
        public async Task<PagedResultDto<UnitListDto>> GetUnitsAsync(GetUnitInput input)
        {
            var query = _menuRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<UnitListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<UnitListDto>(item)).ToList());
        }

        public async Task<GetUnitOutput> GetUnitForEditAsync(NullableIdDto input)
        {
            Unit Unit = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                Unit = await _menuRepository.GetAsync(input.Id.Value);
            }
            var output = new GetUnitOutput();

            output.Unit = Unit != null
                ? ObjectMapper.Map<UnitDto>(Unit)
                : new UnitDto();

            var parentMenuId = output.Unit.ParentId ?? 0;
            output.Units = await _menuRepository.GetAll()
                .Where(m => m.Status)
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name) { IsSelected = parentMenuId == c.Id })
                .ToListAsync();

            return output;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Unit_Create)]
        public async Task<UnitDto> CreateUnitAsync(CreateUnitInput input)
        {
            var entity = ObjectMapper.Map<Unit>(input);
            entity = await _menuRepository.InsertAsync(entity);
            return ObjectMapper.Map<UnitDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Unit_Edit)]
        public async Task<UnitDto> UpdateUnitAsync(UpdateUnitInput input)
        {
            var entity = await _menuRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _menuRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<UnitDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Unit_Delete)]
        public async Task DeleteUnitAsync(EntityDto<int> input)
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

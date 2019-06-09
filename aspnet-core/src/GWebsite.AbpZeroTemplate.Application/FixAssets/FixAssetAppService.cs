using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.FixAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FixAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.FixAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixAsset)]
    public class FixAssetAppService : GWebsiteAppServiceBase, IFixAssetAppService
    {
        private readonly IRepository<FixAsset, int> _menuRepository;

        public FixAssetAppService(IRepository<FixAsset, int> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ListResultDto<FixAssetDto>> GetFixAssetsAsync()
        {

            var items = await _menuRepository.GetAllListAsync();

            return new ListResultDto<FixAssetDto>(
                items.Select(item => ObjectMapper.Map<FixAssetDto>(item)).ToList());

        }

        public async Task<PagedResultDto<FixAssetListDto>> GetFixAssetsAsync(GetFixAssetInput input)
        {
            var query = _menuRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<FixAssetListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<FixAssetListDto>(item)).ToList());
        }

        public async Task<GetFixAssetOutput> GetFixAssetForEditAsync(NullableIdDto input)
        {
            FixAsset FixAsset = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                FixAsset = await _menuRepository.GetAsync(input.Id.Value);
            }
            var output = new GetFixAssetOutput();

            output.FixAsset = FixAsset != null
                ? ObjectMapper.Map<FixAssetDto>(FixAsset)
                : new FixAssetDto();

            var parentMenuId = output.FixAsset.ParentId ?? 0;
            output.FixAssets = await _menuRepository.GetAll()
                .Where(m => m.Status)
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name) { IsSelected = parentMenuId == c.Id })
                .ToListAsync();

            return output;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixAsset_Create)]
        public async Task<FixAssetDto> CreateFixAssetAsync(CreateFixAssetInput input)
        {
            var entity = ObjectMapper.Map<FixAsset>(input);
            entity = await _menuRepository.InsertAsync(entity);
            return ObjectMapper.Map<FixAssetDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixAsset_Edit)]
        public async Task<FixAssetDto> UpdateFixAssetAsync(UpdateFixAssetInput input)
        {
            var entity = await _menuRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _menuRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<FixAssetDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixAsset_Delete)]
        public async Task DeleteFixAssetAsync(EntityDto<int> input)
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

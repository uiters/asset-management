using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.MenuClients
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class MenuClientAppService : GWebsiteAppServiceBase, IMenuClientAppService
    {
        private readonly IRepository<MenuClient, int> _menuRepository;

        public MenuClientAppService(IRepository<MenuClient, int> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ListResultDto<MenuClientDto>> GetMenuClientsAsync()
        {
            
            var items = await _menuRepository.GetAllListAsync();

            return new ListResultDto<MenuClientDto>(
                items.Select(item => ObjectMapper.Map<MenuClientDto>(item)).ToList());
            
        }

        public async Task<PagedResultDto<MenuClientListDto>> GetMenuClientsAsync(GetMenuClientInput input)
        {
            var query = _menuRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<MenuClientListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<MenuClientListDto>(item)).ToList());
        }

        public async Task<GetMenuClientOutput> GetMenuClientForEditAsync(NullableIdDto input)
        {
            MenuClient menuClient = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                menuClient = await _menuRepository.GetAsync(input.Id.Value);
            }
            var output = new GetMenuClientOutput();

            output.MenuClient = menuClient != null
                ? ObjectMapper.Map<MenuClientDto>(menuClient)
                : new MenuClientDto();

            var parentMenuId = output.MenuClient.ParentId ?? 0;
            output.MenuClients = await _menuRepository.GetAll()
                .Where(m => m.Status)
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name) { IsSelected = parentMenuId == c.Id })
                .ToListAsync();

            return output;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        public async Task<MenuClientDto> CreateMenuClientAsync(CreateMenuClientInput input)
        {
            var entity = ObjectMapper.Map<MenuClient>(input);
            entity = await _menuRepository.InsertAsync(entity);
            return ObjectMapper.Map<MenuClientDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        public async Task<MenuClientDto> UpdateMenuClientAsync(UpdateMenuClientInput input)
        {
            var entity = await _menuRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _menuRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<MenuClientDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Delete)]
        public async Task DeleteMenuClientAsync(EntityDto<int> input)
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

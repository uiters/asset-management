using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MenuClientController : GWebsiteControllerBase
    {
        private readonly IMenuClientAppService _menuClientAppService;

        public MenuClientController(IMenuClientAppService menuClientAppService)
        {
            _menuClientAppService = menuClientAppService;
        }

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }

        [HttpGet]
        public async Task<ListResultDto<MenuClientDto>> GetMenuClients()
        {
            return await _menuClientAppService.GetMenuClientsAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<MenuClientListDto>> GetMenuClientsByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _menuClientAppService.GetMenuClientsAsync(new GetMenuClientInput() { Name = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet]
        public string DemoWebApi()
        {
            return "Abcdezz";
        }

        [HttpGet]
        public async Task<GetMenuClientOutput> GetMenuClientForEdit(int id)
        {
            return await _menuClientAppService.GetMenuClientForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public async Task<MenuClientDto> CreateMenuClient([FromBody] CreateMenuClientInput input)
        {
            return await _menuClientAppService.CreateMenuClientAsync(input);
        }

        [HttpPut]
        public async Task<MenuClientDto> UpdateMenuClient([FromBody] UpdateMenuClientInput input)
        {
            return await _menuClientAppService.UpdateMenuClientAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMenuClient(int id)
        {
            await _menuClientAppService.DeleteMenuClientAsync(new EntityDto<int>() { Id = id });
        }
    }
}

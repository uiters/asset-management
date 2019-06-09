using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Units;
using GWebsite.AbpZeroTemplate.Application.Share.Units.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UnitController : GWebsiteControllerBase
    {
        private readonly IUnitAppService _UnitAppService;

        public UnitController(IUnitAppService UnitAppService)
        {
            _UnitAppService = UnitAppService;
        }

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }

        [HttpGet]
        public async Task<ListResultDto<UnitDto>> GetUnits()
        {
            return await _UnitAppService.GetUnitsAsync();
        }
        [HttpGet]
        public UnitCombobox GetUnitCombobox(int? id) => _UnitAppService.GetUnitCombobox(id);

        [HttpGet]
        public async Task<PagedResultDto<UnitListDto>> GetUnitsByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _UnitAppService.GetUnitsAsync(new GetUnitInput() { Name = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet]
        public string DemoWebApi()
        {
            return "Abcdezz";
        }

        [HttpGet]
        public async Task<GetUnitOutput> GetUnitForEdit(int id)
        {
            return await _UnitAppService.GetUnitForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public async Task<UnitDto> CreateUnit([FromBody] CreateUnitInput input)
        {
            return await _UnitAppService.CreateUnitAsync(input);
        }

        [HttpPut]
        public async Task<UnitDto> UpdateUnit([FromBody] UpdateUnitInput input)
        {
            return await _UnitAppService.UpdateUnitAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUnit(int id)
        {
            await _UnitAppService.DeleteUnitAsync(new EntityDto<int>() { Id = id });
        }
    }
}

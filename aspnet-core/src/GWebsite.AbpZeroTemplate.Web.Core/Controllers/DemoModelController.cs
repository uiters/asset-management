using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DemoModelController : GWebsiteControllerBase
    {
        private readonly IDemoModelAppService demoModelAppService;

        public DemoModelController(IDemoModelAppService demoModelAppService)
        {
            this.demoModelAppService = demoModelAppService;
        }

        [HttpGet]
        public PagedResultDto<DemoModelDto> GetDemoModelsByFilter(DemoModelFilter demoModelFilter)
        {
            return demoModelAppService.GetDemoModels(demoModelFilter);
        }

        [HttpGet]
        public DemoModelInput GetDemoModelForEdit(int id)
        {
            return demoModelAppService.GetDemoModelForEdit(id);
        }

        [HttpPost]
        public DemoModelDto CreateOrEditDemoModel([FromBody] DemoModelInput input)
        {
            return demoModelAppService.CreateOrEditDemoModel(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDemoModel(int id)
        {
            demoModelAppService.DeleteDemoModel(id);
        }

        [HttpGet]
        public DemoModelForViewDto GetDemoModelForView(int id)
        {
            return demoModelAppService.GetDemoModelForView(id);
        }

    }
}

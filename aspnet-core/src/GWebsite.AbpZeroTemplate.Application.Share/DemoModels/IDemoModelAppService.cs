using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.DemoModels
{
    public interface IDemoModelAppService
    {
        DemoModelDto CreateOrEditDemoModel(DemoModelInput demoModelInput);
        DemoModelInput GetDemoModelForEdit(int id);
        void DeleteDemoModel(int id);
        PagedResultDto<DemoModelDto> GetDemoModels(DemoModelFilter input);
        DemoModelForViewDto GetDemoModelForView(int id);

    }
}

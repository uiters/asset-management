using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.DemoModels
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class DemoModelAppService : GWebsiteAppServiceBase, IDemoModelAppService
    {
        private readonly IRepository<DemoModel> demoModelRepository;

        public DemoModelAppService(IRepository<DemoModel> demoModelRepository)
        {
            this.demoModelRepository = demoModelRepository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        public DemoModelDto CreateOrEditDemoModel(DemoModelInput demoModelInput)
        {
            DemoModel demoModelEntity = null;
            if (demoModelInput.Id == 0)
            {
                // Insert
                demoModelEntity = ObjectMapper.Map<DemoModel>(demoModelInput);
                SetAuditInsert(demoModelEntity);
                demoModelRepository.Insert(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            else
            {
                // Update
                demoModelEntity = demoModelRepository.GetAll().SingleOrDefault(x => x.Id == demoModelInput.Id);
                if (demoModelEntity == null)
                {
                    return null;
                }
                ObjectMapper.Map(demoModelInput, demoModelEntity);
                SetAuditEdit(demoModelEntity);
                demoModelRepository.Update(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }

            return ObjectMapper.Map<DemoModelDto>(demoModelEntity);
        }

        public void DeleteDemoModel(int id)
        {
            var demoModelEntity = demoModelRepository.Get(id);
            if (demoModelEntity != null)
            {
                demoModelEntity.IsDelete = true;
                demoModelRepository.Update(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DemoModelInput GetDemoModelForEdit(int id)
        {
            var demoModelEntity = demoModelRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (demoModelEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DemoModelInput>(demoModelEntity);
        }

        public DemoModelForViewDto GetDemoModelForView(int id)
        {
            var demoModelEntity = demoModelRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (demoModelEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DemoModelForViewDto>(demoModelEntity);
        }

        public PagedResultDto<DemoModelDto> GetDemoModels(DemoModelFilter input)
        {
            var query = demoModelRepository.GetAll();

            // filter by value
            if (input.Value != null)
            {
                query = query.Where(x => x.Value == input.Value);
            }

            // filter by Date
            if (input.Date != null)
            {
                query = query.Where(x => x.Date == input.Date);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<DemoModelDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DemoModelDto>(item)).ToList());
        }
    }
}

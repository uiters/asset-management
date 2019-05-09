using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Depreciations
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class DepreciationAppService : GWebsiteAppServiceBase, IDepreciationAppService
    {
        private readonly IRepository<Depreciation> DepreciationRepository;

        public DepreciationAppService(IRepository<Depreciation> DepreciationRepository)
        {
            this.DepreciationRepository = DepreciationRepository;
        }

        #region Public Method

        public void CreateOrEditDepreciation(DepreciationInput DepreciationInput)
        {
            if (DepreciationInput.Id == 0)
            {
                Create(DepreciationInput);
            }
            else
            {
                Update(DepreciationInput);
            }
        }

        public void DeleteDepreciation(int id)
        {
            var DepreciationEntity = DepreciationRepository.GetAll().Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == id);
            if (DepreciationEntity != null)
            {
                DepreciationEntity.IsDeleted = true;
                DepreciationRepository.Update(DepreciationEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DepreciationInput GetDepreciationForEdit(int id)
        {
            var DepreciationEntity = DepreciationRepository.GetAll().Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == id);
            if (DepreciationEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DepreciationInput>(DepreciationEntity);
        }

        public DepreciationForViewDto GetDepreciationForView(int id)
        {
            var DepreciationEntity = DepreciationRepository.GetAll().Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == id);
            if (DepreciationEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DepreciationForViewDto>(DepreciationEntity);
        }

        public PagedResultDto<DepreciationDto> GetDepreciations(DepreciationFilter input)
        {
            var query = DepreciationRepository.GetAll().Where(x => !x.IsDeleted);

            // filter by value
            if (input.DepreciationCode != null)
            {
                query = query.Where(x => x.DepreciationCode.ToLower().Equals(input.DepreciationCode));
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
            return new PagedResultDto<DepreciationDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DepreciationDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        //[AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(DepreciationInput DepreciationInput)
        {
            var DepreciationEntity = ObjectMapper.Map<Depreciation>(DepreciationInput);
            //SetAuditInsert(DepreciationEntity);
            DepreciationRepository.Insert(DepreciationEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        //[AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(DepreciationInput DepreciationInput)
        {
            var DepreciationEntity = DepreciationRepository.GetAll().Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == DepreciationInput.Id);
            if (DepreciationEntity == null)
            {
            }
            ObjectMapper.Map(DepreciationInput, DepreciationEntity);
            //SetAuditEdit(DepreciationEntity);
            DepreciationRepository.Update(DepreciationEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}

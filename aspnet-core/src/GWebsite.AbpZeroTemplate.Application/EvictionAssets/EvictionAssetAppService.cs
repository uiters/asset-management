using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset;
using GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.EvictionAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_EvictionAsset)]
    public class EvictionAssetAppService : GWebsiteAppServiceBase, IEvictionAsset
    {
        private readonly IRepository<EvictionAsset> repository;

        public EvictionAssetAppService(IRepository<EvictionAsset> repository)
        {
            this.repository = repository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_EvictionAsset_Create)]
        public EvictionAssetDto CreateEvictionAsset(EvictionAssetDto input)
        {
            EvictionAsset evictionAsset = ObjectMapper.Map<EvictionAsset>(input);
            SetAuditInsert(evictionAsset);
            _ = repository.Insert(evictionAsset);
            CurrentUnitOfWork.SaveChanges();
            return input;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_EvictionAsset_Delete)]
        public void DeleteEvictionAsset(int id)
        {
            EvictionAsset evictionAsset = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (evictionAsset != null)
            {
                evictionAsset.IsDelete = true;
                repository.Update(evictionAsset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ListResultDto<EvictionAssetDto> GetEvictionAssetByCode(string code)
        {
            code = code.ToLower();
            EvictionAsset evictionAsset = repository.GetAll()
                .Where(item => item.AssetCode.ToLower() == code)
                .SingleOrDefault();

            System.Collections.Generic.List<EvictionAssetDto> evictionAssets = new System.Collections.Generic.List<EvictionAssetDto>
            {
                ObjectMapper.Map<EvictionAssetDto>(evictionAsset)
            };
            return new ListResultDto<EvictionAssetDto>(evictionAssets);
        }

        public EvictionAssetDto GetEvictionAssetForEdit(int id)
        {
            EvictionAsset evictionAssets = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<EvictionAssetDto>(evictionAssets);
        }

        public ListResultDto<EvictionAssetDto> GetEvictionAssets()
        {

            System.Collections.Generic.List<EvictionAssetDto> evictionAssets = repository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => ObjectMapper.Map<EvictionAssetDto>(asset))
                .ToList();

            return new ListResultDto<EvictionAssetDto>(evictionAssets);
        }

        public PagedResultDto<EvictionAssetDto> GetEvictionAssetsByFilter(EvictionAssetFilter input)
        {
            IQueryable<EvictionAsset> evictionAssets = repository.GetAll()
                    .Where(item => !item.IsDelete);

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                input.Name = input.Name.ToLower();
                evictionAssets = evictionAssets
                    .Where(asset => asset.AssetName.ToLower().Contains(input.Name));
            }
            int totalCount = evictionAssets.Count();

            System.Collections.Generic.List<EvictionAssetDto> items = evictionAssets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(evictionAsset => ObjectMapper.Map<EvictionAssetDto>(evictionAsset))
                .ToList();

            return new PagedResultDto<EvictionAssetDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_EvictionAsset_Edit)]
        public EvictionAssetDto UpdateEvictionAsset(EvictionAssetDto input)
        {
            EvictionAsset evictionAsset = repository
                .GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == input.Id);
            if (evictionAsset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, evictionAsset);
                SetAuditEdit(evictionAsset);
                evictionAsset = repository.Update(evictionAsset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<EvictionAssetDto>(evictionAsset);
            }
        }
    }
}

using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset;
using GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.LiquidationAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_LiquidationAsset)]
    public class LiquidationAssetAppService : GWebsiteAppServiceBase, ILiquidationAsset
    {
        private readonly IRepository<LiquidationAsset> repository;

        public LiquidationAssetAppService(IRepository<LiquidationAsset> repository)
        {
            this.repository = repository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LiquidationAsset_Create)]
        public LiquidationAssetDto CreateLiquidationAsset(LiquidationAssetDto input)
        {
            LiquidationAsset liquidationAsset = ObjectMapper.Map<LiquidationAsset>(input);
            SetAuditInsert(liquidationAsset);
            _ = repository.Insert(liquidationAsset);
            CurrentUnitOfWork.SaveChanges();
            return input;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LiquidationAsset_Delete)]
        public void DeleteLiquidationAsset(int id)
        {
            LiquidationAsset liquidationAsset = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (liquidationAsset != null)
            {
                liquidationAsset.IsDelete = true;
                repository.Update(liquidationAsset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ListResultDto<LiquidationAssetDto> GetLiquidationAssetByCode(string code)
        {
            code = code.ToLower();
            LiquidationAsset liquidationAsset = repository.GetAll()
                .Where(item => item.AssetCode.ToLower() == code)
                .SingleOrDefault();

            System.Collections.Generic.List<LiquidationAssetDto> liquidationAssets = new System.Collections.Generic.List<LiquidationAssetDto>
            {
                ObjectMapper.Map<LiquidationAssetDto>(liquidationAsset)
            };
            return new ListResultDto<LiquidationAssetDto>(liquidationAssets);
        }

        public LiquidationAssetDto GetLiquidationAssetForEdit(int id)
        {
            LiquidationAsset liquidationAsset = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<LiquidationAssetDto>(liquidationAsset);
        }

        public ListResultDto<LiquidationAssetDto> GetLiquidationAssets()
        {
            System.Collections.Generic.List<LiquidationAssetDto> liquidationAssets = repository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => ObjectMapper.Map<LiquidationAssetDto>(asset))
                .ToList();

            return new ListResultDto<LiquidationAssetDto>(liquidationAssets);
        }

        public PagedResultDto<LiquidationAssetDto> GetLiquidationAssetsByFilter(LiquidationAssetFilter input)
        {
            IQueryable<LiquidationAsset> liquidationAssets = repository.GetAll()
                    .Where(item => !item.IsDelete);

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                input.Name = input.Name.ToLower();
                liquidationAssets = liquidationAssets
                    .Where(asset => asset.AssetName.ToLower().Contains(input.Name));
            }
            int totalCount = liquidationAssets.Count();

            System.Collections.Generic.List<LiquidationAssetDto> items = liquidationAssets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(liquidationAsset => ObjectMapper.Map<LiquidationAssetDto>(liquidationAssets))
                .ToList();

            return new PagedResultDto<LiquidationAssetDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LiquidationAsset_Edit)]
        public LiquidationAssetDto UpdateLiquidationAsset(LiquidationAssetDto input)
        {
            LiquidationAsset liquidationAsset = repository
                .GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == input.Id);
            if (liquidationAsset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, liquidationAsset);
                SetAuditEdit(liquidationAsset);
                liquidationAsset = repository.Update(liquidationAsset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<LiquidationAssetDto>(liquidationAsset);
            }
        }
    }
}

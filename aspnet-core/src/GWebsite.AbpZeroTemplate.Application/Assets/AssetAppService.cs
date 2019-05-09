using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset)]
    public class AssetAppService : GWebsiteAppServiceBase, IAssetAppService
    {
        private readonly IRepository<Asset> assetRepository;

        public AssetAppService(IRepository<Asset> asset)
        {
            assetRepository = asset;
        }

        #region Public Method
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_Create)]
        public AssetDto CreateAsset(AssetInput input)
        {
            Asset asset = ObjectMapper.Map<Asset>(input);
            SetAuditInsert(asset);
            asset = assetRepository.Insert(asset);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<AssetDto>(asset);
        }
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_Delete)]
        public void DeleteAsset(int id)
        {
            Asset asset = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (asset != null)
            {
                asset.IsDelete = true;
                assetRepository.Update(asset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetDto GetAssetByCode(string code)
        {
            Asset asset = assetRepository.GetAll()
                .Where(item => item.AssetCode == code)
                .SingleOrDefault();
            if (asset is null)
            {
                return null;
            }

            return ObjectMapper.Map<AssetDto>(asset);
        }

        public AssetDto GetAssetForEdit(int id)
        {
            Asset asset = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<AssetDto>(asset);
        }

        public ListResultDto<AssetDto> GetAssets()
        {
            System.Collections.Generic.List<AssetDto> assets = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => ObjectMapper.Map<AssetDto>(asset))
                .ToList();

            return new ListResultDto<AssetDto>(assets);
        }

        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter input)
        {
            IQueryable<Asset> assets = assetRepository.GetAll()
                .Where(item => !item.IsDelete);

            // Filter
            if (!string.IsNullOrWhiteSpace(input.AssetName))
            {
                input.AssetName = input.AssetName.ToLower();
                assets = assets
                    .Where(asset => asset.AssetName.ToLower().Contains(input.AssetName));
            }
            int totalCount = assets.Count();

            //Sorting
            System.Collections.Generic.List<AssetDto> items = assets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(item => ObjectMapper.Map<AssetDto>(item))
                .ToList();
            return new PagedResultDto<AssetDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_Edit)]
        public AssetDto UpdateAsset(AssetInput input)
        {
            Asset asset = assetRepository
                .GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == input.Id);
            if (asset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, asset);
                SetAuditEdit(asset);
                asset = assetRepository.Update(asset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<AssetDto>(asset);
            }
        }

        #endregion

    }
}

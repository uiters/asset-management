using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;

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
        public AssetDto CreateAsset(AssetDtoInput input)
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
                .Where(item => !item.IsDelete).SingleOrDefault(item => item.Id == id);
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
                .Where(item => item.AssetCode == code).SingleOrDefault();
            if (asset is null)
                return null;
            return ObjectMapper.Map<AssetDto>(asset);
        }

        public AssetDto GetAssetForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public ListResultDto<AssetDto> GetAssets()
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter input)
        {
            throw new NotImplementedException();
        }

        public AssetDto UpdateAsset(AssetDtoInput input)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

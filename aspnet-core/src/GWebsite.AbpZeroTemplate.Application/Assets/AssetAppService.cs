using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset)]
    public class AssetAppService : GWebsiteAppServiceBase, IAssetAppService
    {
        private readonly IRepository<Asset> assetRepository;
        private readonly IRepository<GroupAsset, int> groupAsset;


        public AssetAppService(IRepository<Asset> asset, IRepository<GroupAsset, int> group)
        {
            assetRepository = asset;
            groupAsset = group;
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

        public ListResultDto<AssetDto> GetAssetByCode(string code)
        {
            code = code.ToLower();
            Asset asset = assetRepository.GetAll()
                .Where(item => item.AssetCode.ToLower() == code)
                .SingleOrDefault();
            //if (asset is null)
            //{
            //    return null;
            //}
            System.Collections.Generic.List<AssetDto> assets = new System.Collections.Generic.List<AssetDto>
            {
                ObjectMapper.Map<AssetDto>(asset)
            };
            return new ListResultDto<AssetDto>(assets);
        }

        public AssetDto GetAssetForEdit(int id)
        {
            Asset asset = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<AssetDto>(asset);
        }
        public AssetCombobox GetAssetCombobox(int? id)
        {
            int idSelect = id ?? 1;
            System.Collections.Generic.List<ComboboxItemDto> assets = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => new ComboboxItemDto(asset.Id.ToString(), asset.AssetName) { IsSelected = asset.Id == idSelect })
                .ToList();

            AssetCombobox assetCombobox = new AssetCombobox
            {
                Assets = assets
            };

            return assetCombobox;
        }
        public ListResultDto<AssetDto> GetAssets()
        {

            Dictionary<string, string> groupAssets = groupAsset
                    .GetAll()
                    .ToDictionary(item => item.Id.ToString(),
                                    item => item.GroupAssetName);

            System.Collections.Generic.List<AssetDto> assets = assetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(MapAsset)
                .ToList();

            AssetDto MapAsset(Asset asset)
            {

                AssetDto assetDto = ObjectMapper.Map<AssetDto>(asset);
                assetDto.GroupAssetName = groupAssets[asset.GroupAssetCode];
                return assetDto;
            }
            return new ListResultDto<AssetDto>(assets);
        }


        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter input)
        {
            Dictionary<string, string> groupAssets = groupAsset
                    .GetAll()
                    .ToDictionary(item => item.Id.ToString(),
                                    item => item.GroupAssetName);

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
                .Select(MapAsset)
                .ToList();

            AssetDto MapAsset(Asset asset)
            {
                AssetDto assetDto = ObjectMapper.Map<AssetDto>(asset);
                assetDto.GroupAssetName = groupAssets[asset.GroupAssetCode];
                return assetDto;
            }
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

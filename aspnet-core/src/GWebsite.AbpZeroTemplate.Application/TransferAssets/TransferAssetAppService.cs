using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TransferAsset;
using GWebsite.AbpZeroTemplate.Application.Share.TransferAsset.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TransferAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferAsset)]
    public class TransferAssetAppService : GWebsiteAppServiceBase, ITransferAsset
    {
        private readonly IRepository<TransferAsset> repository;

        public TransferAssetAppService(IRepository<TransferAsset> repository)
        {
            this.repository = repository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferAsset_Create)]
        public TransferAssetDto CreateTransferAsset(TransferAssetDto input)
        {
            TransferAsset transferAsset = ObjectMapper.Map<TransferAsset>(input);
            SetAuditInsert(transferAsset);
            _ = repository.Insert(transferAsset);
            CurrentUnitOfWork.SaveChanges();
            return input;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferAsset_Delete)]
        public void DeleteTransferAsset(int id)
        {
            TransferAsset transferAsset = repository.GetAll()
                           .Where(item => !item.IsDelete)
                           .SingleOrDefault(item => item.Id == id);
            if (transferAsset != null)
            {
                transferAsset.IsDelete = true;
                repository.Update(transferAsset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ListResultDto<TransferAssetDto> GetTransferAssetByCode(string code)
        {
            code = code.ToLower();
            TransferAsset transferAsset = repository.GetAll()
                .Where(item => item.AssetCode.ToLower() == code)
                .SingleOrDefault();

            System.Collections.Generic.List<TransferAssetDto> transferAssets = new System.Collections.Generic.List<TransferAssetDto>
            {
                ObjectMapper.Map<TransferAssetDto>(transferAsset)
            };
            return new ListResultDto<TransferAssetDto>(transferAssets);
        }

        public TransferAssetDto GetTransferAssetForEdit(int id)
        {
            TransferAsset transferAssets = repository.GetAll()
                           .Where(item => !item.IsDelete)
                           .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<TransferAssetDto>(transferAssets);
        }

        public ListResultDto<TransferAssetDto> GetTransferAssets()
        {
            System.Collections.Generic.List<TransferAssetDto> transferAssets = repository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => ObjectMapper.Map<TransferAssetDto>(asset))
                .ToList();

            return new ListResultDto<TransferAssetDto>(transferAssets);
        }

        public PagedResultDto<TransferAssetDto> GetTransferAssetsByFilter(TransferAssetFilter input)
        {
            IQueryable<TransferAsset> transferAssets = repository.GetAll()
                    .Where(item => !item.IsDelete);

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                input.Name = input.Name.ToLower();
                transferAssets = transferAssets
                    .Where(asset => asset.AssetName.ToLower().Contains(input.Name));
            }
            int totalCount = transferAssets.Count();

            System.Collections.Generic.List<TransferAssetDto> items = transferAssets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(transferAsset => ObjectMapper.Map<TransferAssetDto>(transferAsset))
                .ToList();

            return new PagedResultDto<TransferAssetDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferAsset_Edit)]
        public TransferAssetDto UpdateTransferAsset(TransferAssetDto input)
        {
            TransferAsset transferAsset = repository
                            .GetAll()
                            .Where(item => !item.IsDelete)
                            .SingleOrDefault(item => item.Id == input.Id);
            if (transferAsset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, transferAsset);
                SetAuditEdit(transferAsset);
                transferAsset = repository.Update(transferAsset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<TransferAssetDto>(transferAsset);
            }
        }
    }
}

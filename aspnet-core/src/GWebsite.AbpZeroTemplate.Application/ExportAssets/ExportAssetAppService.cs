using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ExportAsset;
using GWebsite.AbpZeroTemplate.Application.Share.ExportAsset.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ExportAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportAsset)]
    public class ExportAssetAppService : GWebsiteAppServiceBase, IExportAsset
    {
        private readonly IRepository<ExportAsset> repository;

        public ExportAssetAppService(IRepository<ExportAsset> repository)
        {
            this.repository = repository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportAsset_Create)]
        public ExportAssetDto CreateExportAsset(ExportAssetDto input)
        {
            ExportAsset exportAsset = ObjectMapper.Map<ExportAsset>(input);
            SetAuditInsert(exportAsset);
            _ = repository.Insert(exportAsset);
            CurrentUnitOfWork.SaveChanges();
            return input;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportAsset_Delete)]
        public void DeleteExportAsset(int id)
        {
            ExportAsset exportAsset = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (exportAsset != null)
            {
                exportAsset.IsDelete = true;
                repository.Update(exportAsset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ListResultDto<ExportAssetDto> GetExportAssetByCode(string code)
        {
            code = code.ToLower();
            ExportAsset exportAsset = repository.GetAll()
                .Where(item => item.AssetCode.ToLower() == code)
                .SingleOrDefault();

            System.Collections.Generic.List<ExportAssetDto> exportAssets = new System.Collections.Generic.List<ExportAssetDto>
            {
                ObjectMapper.Map<ExportAssetDto>(exportAsset)
            };
            return new ListResultDto<ExportAssetDto>(exportAssets);
        }

        public ExportAssetDto GetExportAssetForEdit(int id)
        {
            ExportAsset exportAsset = repository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<ExportAssetDto>(exportAsset);
        }

        public ListResultDto<ExportAssetDto> GetExportAssets()
        {
            System.Collections.Generic.List<ExportAssetDto> exportAssets = repository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(asset => ObjectMapper.Map<ExportAssetDto>(asset))
                .ToList();

            return new ListResultDto<ExportAssetDto>(exportAssets);
        }

        public PagedResultDto<ExportAssetDto> GetExportAssetsByFilter(ExportAssetFilter input)
        {
            IQueryable<ExportAsset> exportAssets = repository.GetAll()
                                .Where(item => !item.IsDelete);

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                input.Name = input.Name.ToLower();
                exportAssets = exportAssets
                    .Where(asset => asset.AssetName.ToLower().Contains(input.Name));
            }
            int totalCount = exportAssets.Count();

            System.Collections.Generic.List<ExportAssetDto> items = exportAssets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(exportAsset => ObjectMapper.Map<ExportAssetDto>(exportAsset))
                .ToList();

            return new PagedResultDto<ExportAssetDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportAsset_Edit)]
        public ExportAssetDto UpdateExportAsset(ExportAssetDto input)
        {
            ExportAsset exportAsset = repository
                           .GetAll()
                           .Where(item => !item.IsDelete)
                           .SingleOrDefault(item => item.Id == input.Id);
            if (exportAsset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, exportAsset);
                SetAuditEdit(exportAsset);
                exportAsset = repository.Update(exportAsset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<ExportAssetDto>(exportAsset);
            }
        }
    }
}

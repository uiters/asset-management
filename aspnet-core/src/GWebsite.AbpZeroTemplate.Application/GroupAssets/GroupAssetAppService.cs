using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.GroupAssets;
using GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.GroupAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_GroupAsset)]
    public class GroupAssetAppService : GWebsiteAppServiceBase, IGroupAssetAppService
    {

        private readonly IRepository<GroupAsset> groupAssetRepository;

        public GroupAssetAppService(IRepository<GroupAsset> groupAsset)
        {
            groupAssetRepository = groupAsset;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_GroupAsset_Create)]
        public GroupAssetDto CreateGroupAsset(GroupAssetInput input)
        {
            GroupAsset groupAsset = ObjectMapper.Map<GroupAsset>(input);
            SetAuditInsert(groupAsset);
            groupAsset = groupAssetRepository.Insert(groupAsset);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<GroupAssetDto>(groupAsset);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_GroupAsset_Delete)]
        public void DeleteGroupAsset(int id)
        {
            GroupAsset groupAsset = groupAssetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (groupAsset != null)
            {
                groupAsset.IsDelete = true;
                groupAssetRepository.Update(groupAsset);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public GroupAssetCombobox GetGroupAssetCombobox(int? id)
        {
            // combobox auto selecte value by id
            int idSelect = id ?? 1;
            System.Collections.Generic.List<ComboboxItemDto> groupAssets = groupAssetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(groupAsset => new ComboboxItemDto(groupAsset.Id.ToString(), groupAsset.GroupAssetName) { IsSelected = groupAsset.Id == idSelect })
                .ToList();

            GroupAssetCombobox groupAssetCombobox = new GroupAssetCombobox
            {
                GroupAssets = groupAssets
            };

            return groupAssetCombobox;
        }

        public GroupAssetDto GetGroupAssetForEdit(int id)
        {
            GroupAsset groupAsset = groupAssetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<GroupAssetDto>(groupAsset);
        }

        public ListResultDto<GroupAssetDto> GetGroupAssets()
        {
            System.Collections.Generic.List<GroupAssetDto> groupAssets = groupAssetRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(groupAsset => ObjectMapper.Map<GroupAssetDto>(groupAsset))
                .ToList();

            return new ListResultDto<GroupAssetDto>(groupAssets);
        }

        public PagedResultDto<GroupAssetDto> GetGroupAssetsByFilter(GroupAssetFilter input)
        {
            IQueryable<GroupAsset> groupAssets = groupAssetRepository.GetAll()
                .Where(item => !item.IsDelete);

            // Filter
            if (!string.IsNullOrWhiteSpace(input.GroupAssetName))
            {
                input.GroupAssetName = input.GroupAssetName.ToLower();
                groupAssets = groupAssets
                    .Where(groupAsset => groupAsset.GroupAssetName.ToLower().Contains(input.GroupAssetName));
            }
            int totalCount = groupAssets.Count();

            //Sorting
            System.Collections.Generic.List<GroupAssetDto> items = groupAssets
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(item => ObjectMapper.Map<GroupAssetDto>(item))
                .ToList();
            return new PagedResultDto<GroupAssetDto>(totalCount, items);
        }

        public GroupAssetDto GroupAssetByCode(string code)
        {
            GroupAsset groupAsset = groupAssetRepository.GetAll()
                .Where(item => string.Equals(item.AssetTypeCode, code, System.StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();
            if (groupAsset is null)
            {
                return null;
            }

            return ObjectMapper.Map<GroupAssetDto>(groupAsset);
        }
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_GroupAsset_Edit)]
        public GroupAssetDto UpdateGroupAsset(GroupAssetInput input)
        {
            GroupAsset groupAsset = groupAssetRepository
                .GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == input.Id);
            if (groupAsset is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, groupAsset);
                SetAuditEdit(groupAsset);
                groupAsset = groupAssetRepository.Update(groupAsset);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<GroupAssetDto>(groupAsset);
            }
        }
    }
}

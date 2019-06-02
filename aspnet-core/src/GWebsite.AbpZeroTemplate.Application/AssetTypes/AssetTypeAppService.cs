using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Notifications;
using GSoft.AbpZeroTemplate.Authorization.Users;
using GSoft.AbpZeroTemplate.Notifications;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetType)]
    public class AssetTypeAppService : GWebsiteAppServiceBase, IAssetTypeAppService
    {
       
        private readonly IRepository<AssetType> assetTypeRepository;
        //private readonly INotificationPublisher notificationPublisher;
        //private readonly IRepository<User, long> userRepository;
        
        public AssetTypeAppService(IRepository<AssetType> assetType)
        {
            //notificationPublisher = _notificationPublisher;
            assetTypeRepository = assetType;
            //userRepository = _userRepository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetType_Create)]
        public AssetTypeDto CreateAssetType(AssetTypeInput input)
        {
            AssetType assetType = ObjectMapper.Map<AssetType>(input);
            SetAuditInsert(assetType);
            assetType = assetTypeRepository.Insert(assetType);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<AssetTypeDto>(assetType);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetType_Delete)]
        public void DeleteAssetType(int id)
        {
            AssetType assetType = assetTypeRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            if (assetType != null)
            {
                assetType.IsDelete = true;
                assetTypeRepository.Update(assetType);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetTypeDto GetAssetTypeByCode(string code)
        {
            AssetType assetType = assetTypeRepository.GetAll()
                .Where(item => string.Equals(item.AssetTypeCode, code, System.StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();
            if (assetType is null)
            {
                return null;
            }

            return ObjectMapper.Map<AssetTypeDto>(assetType);
        }

        public AssetTypeCombobox GetAssetTypeCombobox(int? id)
        {
            int idSelect = id ?? 1;
            System.Collections.Generic.List<ComboboxItemDto> assetTypes = assetTypeRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(assetType => new ComboboxItemDto(assetType.Id.ToString(), assetType.AssetTypeName) { IsSelected = assetType.Id == idSelect })
                .ToList();

            AssetTypeCombobox assetTypeCombobox = new AssetTypeCombobox
            {
                AssetTypes = assetTypes
            };

            return assetTypeCombobox;
        }

        public AssetTypeDto GetAssetTypeForEdit(int id)
        {
            AssetType assetType = assetTypeRepository.GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == id);
            return ObjectMapper.Map<AssetTypeDto>(assetType);
        }

        public ListResultDto<AssetTypeDto> GetAssetTypes()
        {
            System.Collections.Generic.List<AssetTypeDto> assetTypes = assetTypeRepository.GetAll()
                .Where(item => !item.IsDelete)
                .Select(assetType => ObjectMapper.Map<AssetTypeDto>(assetType))
                .ToList();

            return new ListResultDto<AssetTypeDto>(assetTypes);
        }
       
        public PagedResultDto<AssetTypeDto> GetAssetTypesByFilter(AssetTypeFilter input)
        {
            //var admin = userRepository.GetAll().Where(x => x.Name == "admin").FirstOrDefault();
            //if (admin != null)
            //{
            //    var user = admin.ToUserIdentifier();
            //    //Console.WriteLine(user.UserId);
            //    Console.WriteLine(user.TenantId);
            //    notificationPublisher.PublishAsync(
            //        AppNotificationNames.WelcomeToTheApplication,
            //        new MessageNotificationData(L("WelcomeToTheApplicationNotificationMessage")),
            //        severity: NotificationSeverity.Success,
            //        userIds: new[] { user }
            //        );
            //}
     
            IQueryable<AssetType> assetTypes = assetTypeRepository.GetAll()
                .Where(item => !item.IsDelete);

            // Filter
            if (!string.IsNullOrWhiteSpace(input.AssetTypeName))
            {
                input.AssetTypeName = input.AssetTypeName.ToLower();
                assetTypes = assetTypes
                    .Where(assetType => assetType.AssetTypeName.ToLower().Contains(input.AssetTypeName));
            }
            int totalCount = assetTypes.Count();

            //Sorting
            System.Collections.Generic.List<AssetTypeDto> items = assetTypes
                .OrderBy(input.Sorting)
                .PageBy(input)
                .Select(item => ObjectMapper.Map<AssetTypeDto>(item))
                .ToList();
            return new PagedResultDto<AssetTypeDto>(totalCount, items);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetType_Edit)]
        public AssetTypeDto UpdateAssetType(AssetTypeInput input)
        {
            AssetType assetType = assetTypeRepository
                .GetAll()
                .Where(item => !item.IsDelete)
                .SingleOrDefault(item => item.Id == input.Id);
            if (assetType is null)
            {
                return null;
            }
            else
            {
                ObjectMapper.Map(input, assetType);
                SetAuditEdit(assetType);
                assetType = assetTypeRepository.Update(assetType);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<AssetTypeDto>(assetType);
            }
        }
    }
}

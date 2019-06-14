using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class GWebsiteAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public GWebsiteAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public GWebsiteAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            Permission pages = context.GetPermissionOrNull(GWebsitePermissions.Pages) ?? context.CreatePermission(GWebsitePermissions.Pages, L("Pages"));
            Permission gwebsite = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_GWebsite, L("GWebsite"));

            Permission menuClient = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient, L("MenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Create, L("CreatingNewMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Edit, L("EditingMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Delete, L("DeletingMenuClient"));

            Permission unit = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Unit, L("Unit"));
            unit.CreateChildPermission(GWebsitePermissions.Pages_Administration_Unit_Create, L("CreatingNewUnit"));
            unit.CreateChildPermission(GWebsitePermissions.Pages_Administration_Unit_Edit, L("EditingUnit"));
            unit.CreateChildPermission(GWebsitePermissions.Pages_Administration_Unit_Delete, L("DeletingUnit"));

            Permission fixAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixAsset, L("FixAsset"));
            fixAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixAsset_Create, L("CreatingNewFixAsset"));
            fixAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixAsset_Edit, L("EditingFixAsset"));
            fixAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixAsset_Delete, L("DeletingFixAsset"));

            Permission demoModel = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel, L("DemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Create, L("CreatingNewDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Edit, L("EditingDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Delete, L("DeletingDemoModel"));

            Permission customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            Permission asset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset, L("Asset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Create, L("CreatingNewAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Edit, L("EditingAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Delete, L("DeletingAsset"));

            Permission evictionAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_EvictionAsset, L("EvictionAsset"));
            evictionAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_EvictionAsset_Create, L("CreatingNewEvictionAsset"));
            evictionAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_EvictionAsset_Edit, L("EditingEvictionAsset"));
            evictionAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_EvictionAsset_Delete, L("DeletingEvictionAsset"));

            Permission liquidationAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LiquidationAsset, L("LiquidationAsset"));
            liquidationAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_LiquidationAsset_Create, L("CreatingNewLiquidationAsset"));
            liquidationAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_LiquidationAsset_Edit, L("EditinLiquidationAsset"));
            liquidationAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_LiquidationAsset_Delete, L("DeletingLiquidationAsset"));

            Permission exportAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportAsset , L("ExportAsset"));
            exportAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportAsset_Create, L("CreatingNewExportAsset"));
            exportAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportAsset_Edit, L("EditingExportAsset"));
            exportAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportAsset_Delete, L("DeletingExportAsset"));

            Permission transferAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferAsset, L("TransferAsset"));
            transferAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferAsset_Create, L("CreatingNewTransferAsset"));
            transferAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferAsset_Edit, L("EditingTransferAsset"));
            transferAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferAsset_Delete, L("DeletingTransferAsset"));

            Permission assetType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType, L("AssetType"));
            assetType.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType_Create, L("CreatingNewAssetType"));
            assetType.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType_Edit, L("EditingAssetType"));
            assetType.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType_Delete, L("DeletingAssetType"));

            Permission groupAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_GroupAsset, L("GroupAsset"));
            groupAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_GroupAsset_Create, L("CreatingNewGroupAsset"));
            groupAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_GroupAsset_Edit, L("EditingGroupAsset"));
            groupAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_GroupAsset_Delete, L("DeletingGroupAsset"));

            Permission depreciation = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Depreciation, L("Depreciation"));
            depreciation.CreateChildPermission(GWebsitePermissions.Pages_Administration_Depreciation_Create, L("CreatingNewDepreciation"));
            depreciation.CreateChildPermission(GWebsitePermissions.Pages_Administration_Depreciation_Edit, L("EditingDepreciation"));
            depreciation.CreateChildPermission(GWebsitePermissions.Pages_Administration_Depreciation_Delete, L("DeletingDepreciation"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}

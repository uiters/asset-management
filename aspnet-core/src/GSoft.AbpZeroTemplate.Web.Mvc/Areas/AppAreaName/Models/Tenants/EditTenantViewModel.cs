using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Editions.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tenants
{
    public class EditTenantViewModel
    {
        public TenantEditDto Tenant { get; set; }

        public IReadOnlyList<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public EditTenantViewModel(TenantEditDto tenant, IReadOnlyList<SubscribableEditionComboboxItemDto> editionItems)
        {
            Tenant = tenant;
            EditionItems = editionItems;
        }
    }
}
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Caching.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}
using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units.Dto
{
    public class UnitListDto : Entity<int>
    {
        public string Name { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string User { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }

        
    }
}

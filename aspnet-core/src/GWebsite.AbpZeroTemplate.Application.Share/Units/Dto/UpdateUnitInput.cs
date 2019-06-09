using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units.Dto
{
    public class UpdateUnitInput
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string User { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }
    }
}

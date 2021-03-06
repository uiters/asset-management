﻿using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeInput : Entity<int>
    {
        [Required]
        public string AssetTypeCode { get; set; }
        [Required]
        public string AssetTypeName { get; set; }
        public bool IsReadonly { get; set; }

    }
}

﻿using System;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class EvictionAsset : FullAuditModel
    {
        public DateTime EvictionDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Reason { get; set; }
        public string Content { get; set; }
        public bool IsReadonly { get; set; }
    }
}

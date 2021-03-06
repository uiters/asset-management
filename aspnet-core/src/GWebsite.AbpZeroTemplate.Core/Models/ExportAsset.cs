﻿using System;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ExportAsset : FullAuditModel
    {
        public DateTime ExportDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string UnitName { get; set; }
        public string User { get; set; }
        public bool IsReadonly { get; set; }
    }
}

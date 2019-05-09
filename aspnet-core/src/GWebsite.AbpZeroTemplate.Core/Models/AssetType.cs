using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
   public class AssetType : Entity<int>
    {
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }
    }
}

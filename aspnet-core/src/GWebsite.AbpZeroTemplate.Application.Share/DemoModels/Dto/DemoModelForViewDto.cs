using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto
{
    /// <summary>
    /// <ref cref="DemoModel"></ref>
    /// </summary>
    public class DemoModelForViewDto
    {
        public int? Value { get; set; }
        public string Info { get; set; }
        public string Date { get; set; }
    }
}

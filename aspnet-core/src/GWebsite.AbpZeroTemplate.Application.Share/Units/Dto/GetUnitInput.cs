using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units.Dto
{
    public class GetUnitInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //[Range(1, int.MaxValue)]
        //public int Id { get; set; }

        public string Name { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Name";
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}
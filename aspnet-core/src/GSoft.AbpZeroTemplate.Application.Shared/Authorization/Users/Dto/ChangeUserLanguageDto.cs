using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}

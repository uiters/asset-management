using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}
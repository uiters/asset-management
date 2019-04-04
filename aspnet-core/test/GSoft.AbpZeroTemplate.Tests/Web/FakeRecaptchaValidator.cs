using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Security.Recaptcha;

namespace GSoft.AbpZeroTemplate.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}

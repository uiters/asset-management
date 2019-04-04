using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace GSoft.AbpZeroTemplate.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}

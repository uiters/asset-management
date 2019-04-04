using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace GSoft.AbpZeroTemplate.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}

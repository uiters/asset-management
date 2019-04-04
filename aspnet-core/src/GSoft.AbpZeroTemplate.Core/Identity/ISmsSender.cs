using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}
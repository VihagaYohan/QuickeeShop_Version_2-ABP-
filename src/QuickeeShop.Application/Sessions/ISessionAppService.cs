using System.Threading.Tasks;
using Abp.Application.Services;
using QuickeeShop.Sessions.Dto;

namespace QuickeeShop.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

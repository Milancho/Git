using System.Threading.Tasks;
using Abp.Application.Services;
using Micro.Sessions.Dto;

namespace Micro.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Brenoma.Sessions.Dto;

namespace Brenoma.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

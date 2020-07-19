using System.Threading.Tasks;
using Abp.Application.Services;
using Brenoma.Authorization.Accounts.Dto;

namespace Brenoma.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

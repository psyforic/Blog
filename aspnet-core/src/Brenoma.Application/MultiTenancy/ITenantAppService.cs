using Abp.Application.Services;
using Brenoma.MultiTenancy.Dto;

namespace Brenoma.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


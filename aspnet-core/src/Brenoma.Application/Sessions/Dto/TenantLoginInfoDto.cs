using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Brenoma.MultiTenancy;

namespace Brenoma.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}

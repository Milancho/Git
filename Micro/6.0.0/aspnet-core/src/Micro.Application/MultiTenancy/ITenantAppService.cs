using Abp.Application.Services;
using Micro.MultiTenancy.Dto;

namespace Micro.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


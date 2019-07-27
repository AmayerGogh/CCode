using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CCode.MultiTenancy.Dto;

namespace CCode.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


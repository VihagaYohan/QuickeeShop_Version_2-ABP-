using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickeeShop.MultiTenancy.Dto;

namespace QuickeeShop.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


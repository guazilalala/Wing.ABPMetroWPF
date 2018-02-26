using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject.MultiTenancy.Dto;

namespace MyProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

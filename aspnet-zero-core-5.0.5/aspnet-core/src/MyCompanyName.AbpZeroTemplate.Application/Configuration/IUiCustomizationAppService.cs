using System.Threading.Tasks;
using Abp.Application.Services;
using MyCompanyName.AbpZeroTemplate.Configuration.Dto;

namespace MyCompanyName.AbpZeroTemplate.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<UiCustomizationSettingsEditDto> GetUiManagementSettings();

        Task UpdateUiManagementSettings(UiCustomizationSettingsEditDto settings);

        Task UpdateDefaultUiManagementSettings(UiCustomizationSettingsEditDto settings);

        Task UseSystemDefaultSettings();
    }
}

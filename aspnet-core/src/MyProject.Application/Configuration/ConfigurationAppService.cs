using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyProject.Configuration.Dto;

namespace MyProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

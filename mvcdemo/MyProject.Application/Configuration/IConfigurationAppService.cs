using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject.Configuration.Dto;

namespace MyProject.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
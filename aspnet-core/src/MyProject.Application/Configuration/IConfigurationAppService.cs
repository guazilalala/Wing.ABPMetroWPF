using System.Threading.Tasks;
using MyProject.Configuration.Dto;

namespace MyProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

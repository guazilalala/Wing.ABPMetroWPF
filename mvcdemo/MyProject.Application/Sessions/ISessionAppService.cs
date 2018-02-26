using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject.Sessions.Dto;

namespace MyProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

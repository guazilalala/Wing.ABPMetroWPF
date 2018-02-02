using System.Threading.Tasks;
using Abp.Application.Services;
using Wing.ABPMetroWPF.People.Dto;

namespace Wing.ABPMetroWPF.People
{
    public interface IPersonAppService : IApplicationService
    {
        Task<GetPeopleOutput> GetAllPeopleAsync();

        Task AddNewPerson(AddNewPersonInput input);
    }
}
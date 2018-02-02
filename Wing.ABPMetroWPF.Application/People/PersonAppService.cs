using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Wing.ABPMetroWPF.People.Dto;
using AutoMapper;
using Castle.Core.Logging;

namespace Wing.ABPMetroWPF.People
{
    public class PersonAppService : ABPMetroWPFAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            Logger = NullLogger.Instance;
        }

        public async Task<GetPeopleOutput> GetAllPeopleAsync()
        {
            Logger.Debug("Getting all people");

            return new GetPeopleOutput
                   {
                       People = ObjectMapper.Map<List<PersonDto>>(await _personRepository.GetAllListAsync())
                   };
        }

        public async Task AddNewPerson(AddNewPersonInput input)
        {
            Logger.Debug("Adding a new person: " + input.Name);
            await _personRepository.InsertAsync(new Person { Name = input.Name });
        }
    }
}

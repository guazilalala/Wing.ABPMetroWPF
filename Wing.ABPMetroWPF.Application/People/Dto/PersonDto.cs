using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Wing.ABPMetroWPF.People.Dto
{
	[AutoMap(typeof(Person))]
	public class PersonDto : EntityDto
    {
        public string Name { get; set; }
    }
}
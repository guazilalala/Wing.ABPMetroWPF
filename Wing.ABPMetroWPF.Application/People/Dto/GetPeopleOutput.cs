using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Wing.ABPMetroWPF.People.Dto
{
	[AutoMapFrom(typeof(PersonDto))]
    public class GetPeopleOutput
    {
        public List<PersonDto> People { get; set; }
    }
}
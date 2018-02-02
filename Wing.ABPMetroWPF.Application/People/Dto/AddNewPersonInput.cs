using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Wing.ABPMetroWPF.People.Dto
{
    public class AddNewPersonInput
    {
        [Required]
        public string Name { get; set; }
    }
}
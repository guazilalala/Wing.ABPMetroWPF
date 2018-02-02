using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Wing.ABPMetroWPF.People
{
    [Table("People")]
    public class Person : Entity
    {
        public string Name { get; set; }
    }
}

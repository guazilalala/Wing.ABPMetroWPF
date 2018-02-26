using System.Collections.Generic;
using MyProject.Roles.Dto;
using MyProject.Users.Dto;

namespace MyProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
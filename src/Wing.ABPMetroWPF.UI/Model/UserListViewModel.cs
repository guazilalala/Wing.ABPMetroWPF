using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wing.ABPMetroWPF.Users.Dto;

namespace Wing.ABPMetroWPF.UI.Model
{
	public class UserListViewModel
	{
		public IReadOnlyList<UserDto> Users { get; set; }

		public IReadOnlyList<RoleDto> Roles { get; set; }
	}
}

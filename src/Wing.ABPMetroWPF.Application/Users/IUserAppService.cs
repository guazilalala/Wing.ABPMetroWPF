using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wing.ABPMetroWPF.Users.Dto;

namespace Wing.ABPMetroWPF.Users
{
	public interface IUserAppService: IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
	{
		Task<ListResultDto<RoleDto>> GetRoles();
	}
}

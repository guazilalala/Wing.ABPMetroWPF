using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wing.ABPMetroWPF.Authorization.Roles;
using Wing.ABPMetroWPF.Authorization.Users;
using Wing.ABPMetroWPF.Users.Dto;

namespace Wing.ABPMetroWPF.Users
{
	public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>, IUserAppService
	{
		private readonly UserManager _userManager;
		private readonly RoleManager _roleManager;
		private readonly IRepository<Role> _roleRepository;

		public UserAppService(
			UserManager userManager,
			RoleManager roleManager,
			IRepository<Role> roleRepository,
			IRepository<User,long> repository):base(repository)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_roleRepository = roleRepository;
		}

		public override async Task<UserDto> Create(CreateUserDto input)
		{
			CheckCreatePermission();

			var user = ObjectMapper.Map<User>(input);

			user.TenantId = AbpSession.TenantId;
			user.Password = new PasswordHasher().HashPassword(input.Password);
			user.IsEmailConfirmed = true;

			CheckErrors(await _userManager.CreateAsync(user));

			//分配角色
			if(input.RoleNames != null)
			{
				CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
			}

			CurrentUnitOfWork.SaveChanges();
			return MapToEntityDto(user);
		}

		private void CheckErrors(IdentityResult identityResult)
		{
			identityResult.CheckErrors(LocalizationManager);
		}

		public override Task Delete(EntityDto<long> input)
		{
			throw new NotImplementedException();
		}

		public override Task<UserDto> Get(EntityDto<long> input)
		{
			throw new NotImplementedException();
		}

		public override Task<PagedResultDto<UserDto>> GetAll(PagedResultRequestDto input)
		{
			throw new NotImplementedException();
		}

		public override Task<UserDto> Update(UpdateUserDto input)
		{
			throw new NotImplementedException();;
		}
	}
}

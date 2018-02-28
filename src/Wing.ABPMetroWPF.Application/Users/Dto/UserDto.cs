using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using Wing.ABPMetroWPF.Authorization.Users;

namespace Wing.ABPMetroWPF.Users.Dto
{
	[AutoMapFrom(typeof(User))]
	public class UserDto:EntityDto<long>
	{
		[Required]
		[StringLength(AbpUserBase.MaxUserNameLength)]
		public string UserName { get; set; }

		[Required]
		[StringLength(AbpUserBase.MaxNameLength)]
		public string Name { get; set; }

		[Required]
		[StringLength(AbpUserBase.MaxSurnameLength)]
		public string Surname { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(AbpUserBase.MaxEmailAddressLength)]
		public string EmailAddress { get; set; }

		public bool IsActive { get; set; }

		public string FullName { get; set; }

		public DateTime? LastLoginTime { get; set; }

		public DateTime CreationTime { get; set; }

		public string[] Roles { get; set; }
	}
}

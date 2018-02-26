using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Wing.ABPMetroWPF.Authorization.Users;

namespace Wing.ABPMetroWPF.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserDto
    {
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string FullName { get; set; }

		[StringLength(AbpUserBase.MaxNameLength)]
		public string Name => FullName;

		[StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname => FullName;

		[Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

		[StringLength(User.MaxPhoneNumberLength)]
		public string PhoneNumber { get; set; }
	}
}
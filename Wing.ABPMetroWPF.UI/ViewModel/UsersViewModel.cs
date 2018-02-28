using Abp.Application.Services.Dto;
using Abp.Dependency;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wing.ABPMetroWPF.UI.Model;
using Wing.ABPMetroWPF.Users;
using Wing.ABPMetroWPF.Users.Dto;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
	public class UsersViewModel : ViewModelBase, ISingletonDependency
	{
		private readonly IUserAppService _userAppService;

		private IReadOnlyList<UserDto> _users;
		public UsersViewModel(IUserAppService userAppService)
		{
			_userAppService = userAppService;
			OpenAddUserViewCommand = new RelayCommand(() => OpenAddUserView());
		}



		#region Functions
		private void OpenAddUserView()
		{
			var msg = new NotificationMessageAction<bool>("OpenAddUserViewNotification", async result =>
			{
				if (result)
				{
					var userListViewModel = await GetAllUserAsync();
					Users = userListViewModel.Users;
				}
			});
			Messenger.Default.Send(msg, "OpenAddUserView");
		}

		private async Task<UserListViewModel> GetAllUserAsync()
		{
			var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items;
			var roles = (await _userAppService.GetRoles()).Items;

			return new UserListViewModel
			{
				Users = users,
				Roles = roles
			};
		}
		#endregion
		#region Properties
		public IReadOnlyList<UserDto> Users
		{
			get => _users; set
			{
				_users = value;
				RaisePropertyChanged(() => Users);
			}
		}

		#endregion
		#region Command
		public RelayCommand OpenAddUserViewCommand { get; private set; }
		#endregion
	}
}

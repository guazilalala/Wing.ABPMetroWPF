using Abp.Dependency;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Wing.ABPMetroWPF.UI.Model;
using Wing.ABPMetroWPF.Users;
using Wing.ABPMetroWPF.Users.Dto;
using Abp.ObjectMapping;
using AutoMapper;
using System;
using Abp.Runtime.Validation;
using GalaSoft.MvvmLight.Messaging;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
	public class AddUserViewModel : ViewModelBase, ISingletonDependency
	{
		private CreateUserModel _user;

		private readonly IUserAppService _userAppService;
		public AddUserViewModel(IUserAppService userAppService)
		{
			_userAppService = userAppService;

			AddUserCommand = new RelayCommand(() => AddUser());
		}

		#region Methods
		public override void Cleanup()
		{
			base.Cleanup();
			User = null;
		}

		private async void AddUser()
		{
			var user = Mapper.Map<CreateUserModel>(User);
			user.Password = "123qwe";
			try
			{
			  var result = await _userAppService.Create(user);
				Messenger.Default.Send<object>(null,"AddUserViewSave");
			}
			catch (AbpValidationException ex)
			{

			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region Properties
		public CreateUserModel User
		{
			get
			{
				if (_user == null)
					_user = new CreateUserModel();			
				return _user;
			}
			set
			{
				_user = value;
				RaisePropertyChanged(() => User);
			}
		}
		#endregion

		#region Command
		/// <summary>
		/// 添加用户
		/// </summary>
		public RelayCommand AddUserCommand { get; private set; }
		#endregion
	}
}

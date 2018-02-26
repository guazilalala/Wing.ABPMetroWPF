using System;
using System.Windows.Controls;
using Abp.Dependency;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Wing.ABPMetroWPF.UI.ViewModel.Account
{
	public class AccountViewModel:ViewModelBase, ISingletonDependency
	{
		public AccountViewModel()
		{
		}


		#region Properties
		public string UserName { get; private set; }

		#endregion
		#region Commands
		public RelayCommand<object> LoginCommand
		{
			get
			{
				return new RelayCommand<object>(x => { Login(x);});
			}
		}


		/// <summary>
		/// 登录
		/// </summary>
		/// <returns></returns>
		private void Login(object passwordBox)
		{
			PasswordBox pb = passwordBox as PasswordBox;

			bool isLogon = false;

			if (UserName =="" && pb.Password == "")
			{
				isLogon = true;
			}
			else
			{
				isLogon = false;
			}
			isLogon = true;
			Messenger.Default.Send<bool?>(isLogon, "Login");

		}
		#endregion

		#region Methods

		#endregion

		public override void Cleanup()
		{
			base.Cleanup();
		}
	}
}

using Abp.Dependency;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
	public class UsersViewModel : ViewModelBase, ISingletonDependency
	{
		public UsersViewModel()
		{
			OpenAddUserViewCommand = new RelayCommand(()=>OpenAddUserView());
		}

		private void OpenAddUserView()
		{
			var msg = new NotificationMessageAction<bool>("OpenAddUserViewNotification",result=> 
			{
				if (result)
				{

				}
			});
			Messenger.Default.Send(msg, "OpenAddUserView");
		}

		#region Command
		public RelayCommand OpenAddUserViewCommand { get; private set; }
		#endregion
	}
}

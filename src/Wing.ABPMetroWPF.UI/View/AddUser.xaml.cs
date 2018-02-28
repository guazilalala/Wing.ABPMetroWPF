using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Wing.ABPMetroWPF.UI.ViewModel;

namespace Wing.ABPMetroWPF.UI.View
{
	/// <summary>
	/// AddUser.xaml 的交互逻辑
	/// </summary>
	public partial class AddUser : MetroWindow
	{
		public AddUser()
		{
			InitializeComponent();
			this.Owner = Application.Current.MainWindow;
			Messenger.Default.Register<object>(this, "AddUserViewSave", Save);
			this.Unloaded += AddUser_Unloaded;
		}

		private void Save(object obj)
		{
			this.DialogResult = true;
		}

		private void AddUser_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			AddUserViewModel viewModel = this.DataContext as AddUserViewModel;
			viewModel.Cleanup();
		}

		private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}

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

			this.Unloaded += AddUser_Unloaded;
		}

		private void AddUser_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			AddUserViewModel viewModel = this.DataContext as AddUserViewModel;
			viewModel.Cleanup();
		}
	}
}

using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace BingShengReportToBill
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			Messenger.Default.Register<string>(this, "ShowErrorMessage", x => 
			{
				this.ShowMessageAsync("提示", x, MessageDialogStyle.Affirmative);
			});
		}

		private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			e.Row.Header = (e.Row.GetIndex() + 1).ToString();
		}

		private void btnLink_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("Http://www.kuan1.cn");
		}
	}
}

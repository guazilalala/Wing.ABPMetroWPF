using BingShengReportToBill.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
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
				var msgSettings = new MetroDialogSettings
				{
					AffirmativeButtonText = "确定",
					MaximumBodyHeight = 120			
				};

				this.ShowMessageAsync("提示", x, MessageDialogStyle.Affirmative, msgSettings).ContinueWith(t =>
				{

					if (t.Result == MessageDialogResult.Affirmative)
					{
						Environment.Exit(0);
					}
				}
				);
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

		private void load_Loaded(object sender, RoutedEventArgs e)
		{
			var viewModel = this.DataContext as MainViewModel;
			viewModel.ValidationConfign();
		}
	}
}

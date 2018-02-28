using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wing.ABPMetroWPF.UI.Dialog
{
	public class DialogService : IDialogService
	{
		public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException();
		}

		public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException();
		}

		public Task ShowMessage(string message, string title)
		{
			 return	Task.Factory.StartNew(()=> 
			 {
				 DispatcherHelper.CheckBeginInvokeOnUI(() =>
				 {
					 MessageBox.Show(Application.Current.MainWindow, message, title, MessageBoxButton.OK, MessageBoxImage.Information);
				 });
			 });
		}

		public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
		{
			return Task.Factory.StartNew(() =>
			{
				MessageBox.Show(message, title);
				afterHideCallback.Invoke();
			});
		}

		public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
		{
			throw new NotImplementedException();
		}

		public Task ShowMessageBox(string message, string title)
		{
			throw new NotImplementedException();
		}
	}
}

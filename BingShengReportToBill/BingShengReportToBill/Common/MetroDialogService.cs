using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Threading.Tasks;

namespace BingShengReportToBill.Common
{
	public class MetroDialogService : MetroWindow, IDialogService
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
			// This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
			// The package is only used by the demo and not a dependency of the library!
			var mySettings = new MetroDialogSettings()
			{
				AffirmativeButtonText = "Hi",
				NegativeButtonText = "Go away!",
				FirstAuxiliaryButtonText = "Cancel",
				ColorScheme = this.MetroDialogOptions.ColorScheme
			};

			return Task.Factory.StartNew(() =>
			{
				DispatcherHelper.CheckBeginInvokeOnUI(() =>
				{
					this.ShowMessageAsync(title, message,
MessageDialogStyle.Affirmative, mySettings);
				});

			});

			//if (result != MessageDialogResult.FirstAuxiliary)
			//	DialogManager.ShowMessageAsync(this, "Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
			//		Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));


		}

		public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException();
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

using BingShengReportToBill.Helper;
using BingShengReportToBill.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls.Dialogs;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace BingShengReportToBill.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly AppConfig _appConfig = new AppConfig();
		private ObservableCollection<Order> _orders;
		private Order _selectedOrder;
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel()
		{
			UploadCommand = new RelayCommand<DateTime>(x => UploadOrder(x));

			UploadButtonEnabled = true;
			UploadTipsVisibility = false;
		}


		#region Properties
		private int _successfulCount { get; set; }
		public int SuccessfulCount
		{
			get
			{
				return _successfulCount;
			}

			set
			{
				_successfulCount = value;
				RaisePropertyChanged(() => SuccessfulCount);
			}
		}

		private int _failuresCount { get; set; }
		public int FailuresCount
		{
			get
			{
				return _failuresCount;
			}

			set
			{
				_failuresCount = value;
				RaisePropertyChanged(() => FailuresCount);
			}
		}

		private bool _processingEnabled;
		public bool ProcessingEnabled
		{
			get
			{
				return _processingEnabled;
			}

			set
			{
				_processingEnabled = value;
				RaisePropertyChanged(() => ProcessingEnabled);
			}
		}

		private bool _uploadTipsVisibility;
		public bool UploadTipsVisibility
		{
			get
			{
				return _uploadTipsVisibility;
			}

			set
			{
				_uploadTipsVisibility = value;
				RaisePropertyChanged(() => UploadTipsVisibility);
			}
		}

		private bool _uploadButtonEnabled;
		public bool UploadButtonEnabled
		{
			get
			{
				return _uploadButtonEnabled;
			}

			set
			{
				_uploadButtonEnabled = value;
				ProcessingEnabled = !_uploadButtonEnabled;
				RaisePropertyChanged(() => UploadButtonEnabled);
			}
		}

		public ObservableCollection<Order> Orders
		{
			get
			{
				if (_orders == null)
					_orders = new ObservableCollection<Order>();
				return _orders;
			}

			set
			{
				_orders = value;
				RaisePropertyChanged(() => Orders);
			}
		}
		public Order SelectedOrder
		{
			get { return _selectedOrder; }
			set
			{
				_selectedOrder = value;
				RaisePropertyChanged(()=>SelectedOrder);
			}
		}

		#endregion

		#region Functions
		private void UploadOrder(DateTime date)
		{
			#region 验证配置信息
			List<ValidationResult> validationResult;
			var validation = ValidateHelper.ValidateConfig(_appConfig, out validationResult);
			if (!validation)
			{
				string resultStr = string.Join<ValidationResult>("|", validationResult.ToArray());
			}
			#endregion

			UploadButtonEnabled = false;
			UploadTipsVisibility = true;
			SuccessfulCount = 0;
			FailuresCount = 0;

			var uploadDate = date.ToString("yyyy-MM-dd");

			Task.Factory.StartNew(() =>
			{
				for (int i = 0; i < 100; i++)
				{
					DispatcherHelper.CheckBeginInvokeOnUI(() =>
					{
						var order = new Order { Id = DateTime.Now.ToString("yyyyMMddHHmmss"), UploadSuccess = true, UploadTime = DateTime.Now };
						Orders.Add(order);
						SuccessfulCount++;
						SelectedOrder = order;
					});
					Thread.Sleep(100);
				}
				UploadButtonEnabled = true;
			});
		}

		#endregion

		#region Commands
		public RelayCommand<DateTime> UploadCommand { get; set; }
		#endregion
	}
}
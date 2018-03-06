using BingShengReportToBill.Helper;
using BingShengReportToBill.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
		private int _selectedIndex;
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel()
		{
			UploadCommand = new RelayCommand<DateTime>(x => UploadOrder(x));
		}


		#region Properties
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


		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				_selectedIndex = value;
				RaisePropertyChanged(() => SelectedIndex);
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



			var uploadDate = date.ToString("yyyy-MM-dd");

			Task.Factory.StartNew(() =>
			{
				while (true)
				{
					DispatcherHelper.CheckBeginInvokeOnUI(() =>
					{
						var order = new Order { Id = DateTime.Now.ToString("yyyyMMddHHmmss"), UploadSuccess = true, UploadTime = DateTime.Now };
						Orders.Add(order);
						SelectedOrder = order;
					});

					Thread.Sleep(1000);
				}

			});
		}

		#endregion

		#region Commands
		public RelayCommand<DateTime> UploadCommand { get; set; }
		#endregion
	}
}
using BingShengReportToBill.Helper;
using BingShengReportToBill.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace BingShengReportToBill.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly InterBaseHelper _interBaseHelper;
		private ObservableCollection<Folio> _folios;
		private int _successfulCount;
		private int _failuresCount;
		private bool _processingEnabled;
		private bool _uploadTipsVisibility;
		private bool _uploadButtonEnabled;
		private bool _isTimingUpload;
		private string _timingUploadTime;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel()
		{
			_interBaseHelper = new InterBaseHelper(AppConfig.DatabaseFile, AppConfig.UserName, AppConfig.Password, AppConfig.ServerName);
			UploadCommand = new RelayCommand<DateTime>(x => UploadOrder(x));
			UploadButtonEnabled = true;
			UploadTipsVisibility = false;

			IsTimingUpload = AppConfig.IsTimingUpload;
			TimingUploadTime = AppConfig.TimingUploadTime;
		}

		#region Properties
		/// <summary>
		/// 是否定时上报
		/// </summary>
		public bool IsTimingUpload
		{
			get
			{
				return _isTimingUpload;
			}

			set
			{
				_isTimingUpload = value;
				RaisePropertyChanged(() => IsTimingUpload);
			}
		}

		public string TimingUploadTime
		{
			get
			{
				return _timingUploadTime;
			}

			set
			{
				_timingUploadTime = value;
				RaisePropertyChanged(() => TimingUploadTime);
			}
		}

		/// <summary>
		/// 上传成功的订单数量
		/// </summary>
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
		/// <summary>
		/// 上传失败的订单数量
		/// </summary>
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
		/// <summary>
		/// 订单列表
		/// </summary>
		public ObservableCollection<Folio> Folios
		{
			get
			{
				if (_folios == null)
					_folios = new ObservableCollection<Folio>();
				return _folios;
			}

			set
			{
				_folios = value;
				RaisePropertyChanged(() => Folios);
			}
		}
		#endregion

		#region Functions
		/// <summary>
		/// 上报订单,
		/// </summary>
		/// <param name="date">上报日期</param>
		private void UploadOrder(DateTime date)
		{
			#region 验证配置信息
			List<ValidationResult> validationResult;
			var validation = ValidateHelper.ValidateConfig(new AppConfig(), out validationResult);
			if (!validation)
			{
				string resultStr = string.Join<ValidationResult>("|", validationResult.ToArray());
			}
			#endregion
			//string tableTime = date.ToString("yyMMdd");
			string tableDate = date.ToString("180101");

			var tenderCodeArray = AppConfig.TenderCode.Split(',');
			for (int i = 0; i < tenderCodeArray.Length; i++)
			{
				tenderCodeArray[i] = "'" + tenderCodeArray[i] + "'";
			}
			string tenderCodes = string.Join(",", tenderCodeArray);


			Folios.Clear();
			SuccessfulCount = 0;
			FailuresCount = 0;
			UploadButtonEnabled = false;
			UploadTipsVisibility = true;

			Task.Factory.StartNew(() =>
			{
				string queryFolioSql = "SELECT STARTTIM,SERIAL,AMT FROM FOLIO" + tableDate + " WHERE SERIAL IN(SELECT SERIAL FROM FOLIOPAYMENT" + tableDate + " WHERE PAYMENTDES IN (" + tenderCodes + ") GROUP BY SERIAL)";
				var folios = _interBaseHelper.ReadFolioData(queryFolioSql);
				foreach (var folio in folios)
				{
					string strCallUserCode = AppConfig.CallUserCode;
					string strCallPassword = AppConfig.CallPassword;
					string strStoreCode = AppConfig.StoreCode;
					string strType = "SA";
					string strSalesDate = folio.StartTim.ToString("yyyyMMdd");
					string strSalesTime = folio.StartTim.ToString("HHMMSS"); ;
					string strSalesDocNo = folio.Serial;
					string strVipCode = "";
					string strTenderCode = GetStrTenderCodes(tableDate, folio.Serial);
					string strRemark = "";
					string strItems = GetStrItems(tableDate, folio.Serial);

					var posResult = PostToServer(strCallUserCode,
							strCallPassword,
							strStoreCode,
							strType,
							strSalesDate,
							strSalesTime,
							strSalesDocNo,
							strVipCode,
							strTenderCode,
							strRemark,
							strItems);


					DispatcherHelper.CheckBeginInvokeOnUI(() =>
					{
						Folios.Add(new Folio
						{
							Serial = folio.Serial,
							Amt = folio.Amt,
							StartTim = folio.StartTim,
							UploadSuccess = posResult
						});
					});


					if (posResult)
					{
						SuccessfulCount++;
					}
					else
					{
						FailuresCount++;
					}
				}

			}).ContinueWith(x => { UploadButtonEnabled = true; });
		}

		/// <summary>
		/// 上报订单数据到物业
		/// </summary>
		/// <param name="strCallUserCode"></param>
		/// <param name="strCallPassword"></param>
		/// <param name="strStoreCode"></param>
		/// <param name="strType"></param>
		/// <param name="strSalesDate"></param>
		/// <param name="strSalesTime"></param>
		/// <param name="strSalesDocNo"></param>
		/// <param name="strVipCode"></param>
		/// <param name="strTenderCode"></param>
		/// <param name="strRemark"></param>
		/// <param name="strItems"></param>
		private bool PostToServer(string strCallUserCode,
								string strCallPassword,
								string strStoreCode,
								string strType,
								string strSalesDate,
								string strSalesTime,
								string strSalesDocNo,
								string strVipCode,
								string strTenderCode,
								string strRemark,
								string strItems)
		{
			_logger.Info(string.Format("strStoreCode:{0}|strType:{1}|strSalesDate:{2}|strSalesTime:{3}|strSalesDocNo:{4}|strVipCode:{5}|strTenderCode:{6}|strRemark:{7}|strItems:{8}",
								strStoreCode,
								strType,
								strSalesDate,
								strSalesTime,
								strSalesDocNo,
								strVipCode,
								strTenderCode,
								strRemark,
								strItems));

			return true;
			//pos.PostSales(strCallUserCode, strCallPassword, strStoreCode, strType,
			//	strSalesDate, strSalesTime, strSalesDocNo, strVipCode, strTenderCode, strRemark, strItems);

		}

		/// <summary>
		/// 获取strTenderCode
		/// </summary>
		/// <param name="tableDate">表日期</param>
		/// <param name="serial">订单号</param>
		/// <returns></returns>
		public string GetStrTenderCodes(string tableDate, string serial)
		{
			List<string> tenderCodeList = new List<string>();
			string queryFolioPaymentSql = "SELECT PAYMENTDES,AMT FROM FOLIOPAYMENT" + tableDate + " WHERE SERIAL=" + serial + "";
			var queryFolioPaymentResult = _interBaseHelper.ReadFolioPaymentData(queryFolioPaymentSql);

			int changeAmount = 0;
			int excessAmount = 0;
			foreach (var item in queryFolioPaymentResult)
			{
				string payNum = "11";

				if (AppConfig.PayDictionary.ContainsKey(item.PaymentDes))
				{
					payNum = AppConfig.PayDictionary[item.PaymentDes];
				}
				string str = string.Format("{{{0},{1},{2},{3}}}", payNum, item.Amt, changeAmount, excessAmount);
				tenderCodeList.Add(str);
			}
			var returnValue = string.Join(",", tenderCodeList.ToArray());
			return returnValue;
		}
		/// <summary>
		/// 获取strItems
		/// </summary>
		/// <param name="tableName">表日期</param>
		/// <param name="serial">订单号</param>
		/// <returns></returns>
		public string GetStrItems(string tableName, string serial)
		{
			List<string> strItemsList = new List<string>();

			string queryOrdrSql = "SELECT CNT,AMT,DISC FROM ORDR" + tableName + " WHERE CODE =" + serial + "";
			var queryOrderResult = _interBaseHelper.ReadOrdrData(queryOrdrSql);

			foreach (var ordr in queryOrderResult)
			{
				string str = string.Format("{{{0},{1},{2}}}", AppConfig.SKU, ordr.Cnt, ordr.Amt);
				strItemsList.Add(str);
			}

			var returnValue = string.Join(",", strItemsList.ToArray());
			return returnValue;
		}
		#endregion

		#region Commands
		public RelayCommand<DateTime> UploadCommand { get; set; }
		#endregion
	}
}
using BingShengReportToBill.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;

namespace BingShengReportToBill
{
	public sealed class AppConfig
	{
		private static AppConfig _instance = null;
		private static readonly object _lock = new object();
		private AppConfig()
		{
			ServerName = ConfigurationManager.AppSettings.Get("ServerName");
			DatabaseFile = ConfigurationManager.AppSettings.Get("DatabaseFile");
			UserName = ConfigurationManager.AppSettings.Get("UserName");
			Password = ConfigurationManager.AppSettings.Get("Password");
			CallUserCode = ConfigurationManager.AppSettings.Get("CallUserCode");
			CallPassword = ConfigurationManager.AppSettings.Get("CallPassword");
			StoreCode = ConfigurationManager.AppSettings.Get("StoreCode");
			TenderCode = ConfigurationManager.AppSettings.Get("TenderCode");
			SKU = ConfigurationManager.AppSettings.Get("SKU");
			PayCashNum = ConfigurationManager.AppSettings.Get("PayCashNum");
			PayCash = ConfigurationManager.AppSettings.Get("PayCash");
			PayCardNum = ConfigurationManager.AppSettings.Get("PayCardNum");
			PayCard = ConfigurationManager.AppSettings.Get("PayCard");
			DefaultPayNum = ConfigurationManager.AppSettings.Get("DefaultPayNum");

			bool convertToBool;
			Boolean.TryParse(ConfigurationManager.AppSettings.Get("IsTimingUpload"),out convertToBool);
			IsTimingUpload = convertToBool;

			TimingUploadTime = ConfigurationManager.AppSettings.Get("TimingUploadTime");
			DateTime tempTimingUploadTime;
			if (!DateTime.TryParse(TimingUploadTime, out tempTimingUploadTime))
				TimingUploadTime = "23:59";
			
			var payCashDic = PayCash.Split(',').ToDictionaryEx(key => key, value => PayCashNum);
			var payCardDic = PayCard.Split(',').ToDictionaryEx(key => key, value => PayCardNum);

			PayDictionary = new Dictionary<string, string>();
			payCashDic.ToList().ForEach(x => 
			{
				if (!PayDictionary.ContainsKey(x.Key))
					PayDictionary.Add(x.Key, x.Value);
			} );
			payCardDic.ToList().ForEach(x => {
				if (!PayDictionary.ContainsKey(x.Key))
					PayDictionary.Add(x.Key, x.Value);
			});
		}

		public static AppConfig Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						return new AppConfig();
					}
				}
				return _instance;
			}
		}

		public static string AppVersion => "1.0.18.0312";

		/// <summary>
		/// 数据库IP地址
		/// </summary>
		[Required]
		public string ServerName { get; private set; }
		/// <summary>
		/// 数据库路径
		/// </summary>
		[Required]
		public string DatabaseFile { get; private set; }
		/// <summary>
		/// 数据库登录名
		/// </summary>
		[Required]
		public string UserName { get; private set; }
		/// <summary>
		/// 数据库登录密码
		/// </summary>
		[Required]
		public string Password { get; private set; }
		/// <summary>
		/// 使用者用户名
		/// </summary>
		[Required]
		public string CallUserCode { get; private set; }
		/// <summary>
		/// 使用者密码
		/// </summary>
		[Required]
		public string CallPassword { get; private set; }
		/// <summary>
		/// 店铺号
		/// </summary>
		[Required]
		public string StoreCode { get; private set; }
		/// <summary>
		/// 所要的支付方式(字符串)
		/// </summary>
		[Required]
		public string TenderCode { get; private set; }
		/// <summary>
		/// 货号
		/// </summary>
		[Required]
		public string SKU { get; private set; }
		/// <summary>
		/// 现金支付:上传到11
		/// </summary>
		[Required]
		public string PayCashNum { get; private set; }
		/// <summary>
		/// 现金支付下的支付方式
		/// </summary>
		[Required]
		public string PayCash { get; private set; }
		/// <summary>
		/// 国内卡支付：上传到12
		/// </summary>
		[Required]
		public string PayCardNum { get; private set; }
		/// <summary>
		/// 国内卡支付下的支付方式
		/// </summary>
		[Required]
		public string PayCard { get; private set; }

		/// <summary>
		/// 支付方式对应接口支付编码的字典
		/// </summary>
		[Required]
		public Dictionary<string, string> PayDictionary { get ; private set; }

		/// <summary>
		/// 是否定时上报
		/// </summary>
		public bool IsTimingUpload { get; set; }
		/// <summary>
		/// 定时上报时间
		/// </summary>
		public string TimingUploadTime { get; set; }

		/// <summary>
		/// 默认的支付方式编码
		/// </summary>
		[Required]
		public string DefaultPayNum { get; set; }
	}
}

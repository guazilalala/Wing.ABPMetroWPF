using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BingShengReportToBill
{
	public class AppConfig
	{
		static AppConfig()
		{
			ServerName = ConfigurationManager.AppSettings.Get("ServerName");
			DatabaseFile = ConfigurationManager.AppSettings.Get("DatabaseFile");
			UserName = ConfigurationManager.AppSettings.Get("UserName");
			Password = ConfigurationManager.AppSettings.Get("Password");
			ApiUserCode = ConfigurationManager.AppSettings.Get("ApiUserCode");
			ApiPassword = ConfigurationManager.AppSettings.Get("ApiPassword");
			StoreCode = ConfigurationManager.AppSettings.Get("StoreCode");
			TenderCode = ConfigurationManager.AppSettings.Get("TenderCode");
			SKU = ConfigurationManager.AppSettings.Get("SKU");
			PayCashNum = ConfigurationManager.AppSettings.Get("PayCashNum");
			PayCash = ConfigurationManager.AppSettings.Get("PayCash");
			PayCardNum = ConfigurationManager.AppSettings.Get("PayCardNum");
			PayCard = ConfigurationManager.AppSettings.Get("PayCard");
		}

		/// <summary>
		/// 数据库IP地址
		/// </summary>
		[Required]
		public static string ServerName { get; private set; }
		/// <summary>
		/// 数据库路径
		/// </summary>
		[Required]
		public static string DatabaseFile { get; private set; }
		/// <summary>
		/// 数据库登录名
		/// </summary>
		[Required]
		public static string UserName { get; private set; }
		/// <summary>
		/// 数据库登录密码
		/// </summary>
		[Required]
		public static string Password { get; private set; }
		/// <summary>
		/// 使用者用户名
		/// </summary>
		[Required]
		public static string ApiUserCode { get; private set; }
		/// <summary>
		/// 使用者密码
		/// </summary>
		[Required]
		public static string ApiPassword { get; private set; }
		/// <summary>
		/// 店铺号
		/// </summary>
		[Required]
		public static string StoreCode { get; private set; }
		/// <summary>
		/// 所要的支付方式(字符串)
		/// </summary>
		[Required]
		public static string TenderCode { get; private set; }
		/// <summary>
		/// 货号
		/// </summary>
		[Required]
		public static string SKU { get; private set; }
		/// <summary>
		/// 现金支付:上传到11
		/// </summary>
		[Required]
		public static string PayCashNum { get; private set; }
		/// <summary>
		/// 现金支付下的支付方式
		/// </summary>
		[Required]
		public static string PayCash { get; private set; }
		/// <summary>
		/// 国内卡支付：上传到12
		/// </summary>
		[Required]
		public static string PayCardNum { get; private set; }
		/// <summary>
		/// 国内卡支付下的支付方式
		/// </summary>
		[Required]
		public static string PayCard { get; private set; }

	}
}

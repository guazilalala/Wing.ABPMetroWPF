using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingShengReportToBill.Model
{
	public class FolioPayment
	{
		/// <summary>
		/// 支付方式
		/// </summary>
		public string PaymentDes { get; set; }

		/// <summary>
		/// 金额
		/// </summary>
		public double Amt { get; set; }
	}
}

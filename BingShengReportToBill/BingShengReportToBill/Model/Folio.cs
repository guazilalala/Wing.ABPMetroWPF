﻿using System;

namespace BingShengReportToBill.Model
{
	public class Folio
    {
		/// <summary>
		/// 订单号
		/// </summary>
		public string Serial { get; set; }
		/// <summary>
		/// 订单时间
		/// </summary>
		public DateTime StartTim { get; set; }
		/// <summary>
		/// 金额
		/// </summary>
		public string Amt { get; set; }
		/// <summary>
		/// 上传状态
		/// </summary>
		public bool UploadSuccess { get; set; }
	}
}
﻿using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace BingShengReportToBill
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			DispatcherHelper.Initialize();
		}
	}
}

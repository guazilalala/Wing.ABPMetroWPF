using GalaSoft.MvvmLight.Threading;
using NLog;
using System.Windows;

namespace BingShengReportToBill
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
		private Logger _logger;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			this.DispatcherUnhandledException += App_DispatcherUnhandledException;
			DispatcherHelper.Initialize();
			_logger = LogManager.GetCurrentClassLogger();
		}

		private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			_logger.Error(string.Format("程序异常错误:{0}.",e.Exception));
			e.Handled = true;
		}
	}
}

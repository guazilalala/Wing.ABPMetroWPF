using System;
using System.Windows;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Castle.Facilities.Logging;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro;
using Wing.ABPMetroWPF.UI.View;

namespace Wing.ABPMetroWPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AbpBootstrapper _bootstrapper;
        private MainWindow _mainWindow;

        public App()
        {
            DispatcherHelper.Initialize();
            _bootstrapper = AbpBootstrapper.Create<ABPMetroWPFUiModule>();
            _bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
			_bootstrapper.Initialize();

			#region 主题颜色
			// get the current app style (theme and accent) from the application
			// you can then use the current theme and custom accent instead set a new theme
			Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

			// now set the Green accent and dark theme
			ThemeManager.ChangeAppStyle(Application.Current,
										ThemeManager.GetAccent("Red"),
										ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
			#endregion


			_mainWindow = _bootstrapper.IocManager.Resolve<MainWindow>();
			_mainWindow.Show();
		}

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper.IocManager.Release(_mainWindow);
            _bootstrapper.Dispose();
        }
    }
}

using System;
using System.Windows;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Castle.Facilities.Logging;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro;
using Wing.ABPMetroWPF.UI.View;
using Wing.ABPMetroWPF.UI.View.Account;

namespace Wing.ABPMetroWPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AbpBootstrapper _bootstrapper;

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
										ThemeManager.GetAccent("Green"),
										ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
			#endregion

			//将LoginView设为主窗体
			LoginView loginView = _bootstrapper.IocManager.Resolve<LoginView>();
			MainWindow = loginView;
			MainWindow.Show();

			//注册消息,返回true为登录成功
			Messenger.Default.Register<bool?>(this,"Login", m =>
			{
				if (m.Value == true)
				{
					MainWindow = _bootstrapper.IocManager.Resolve<MainWindow>();
					loginView.Close();
					MainWindow.Show();
				}
			});
		}

        protected override void OnExit(ExitEventArgs e)
        {
			Messenger.Default.Unregister(this);
			_bootstrapper.IocManager.Release(MainWindow);
            _bootstrapper.Dispose();
        }
    }
}

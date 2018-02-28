using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Wing.ABPMetroWPF.UI.Theme
{
	public class AccentColorMenuData:ViewModelBase
	{
		public string Name { get; set; }
		public Brush BorderColorBrush { get; set; }
		public Brush ColorBrush { get; set; }

		private RelayCommand<object> changeAccentCommand;

		public RelayCommand<object> ChangeAccentCommand
		{
			get { return this.changeAccentCommand ?? (changeAccentCommand = new RelayCommand<object>(x => DoChangeTheme(x))); }
		}

		protected virtual void DoChangeTheme(object sender)
		{
			var theme = ThemeManager.DetectAppStyle(Application.Current);
			var accent = ThemeManager.GetAccent(this.Name);
			ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
		}
	}

	public class AppThemeMenuData : AccentColorMenuData
	{
		protected override void DoChangeTheme(object sender)
		{
			var theme = ThemeManager.DetectAppStyle(Application.Current);
			var appTheme = ThemeManager.GetAppTheme(this.Name);
			ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
		}
	}

}

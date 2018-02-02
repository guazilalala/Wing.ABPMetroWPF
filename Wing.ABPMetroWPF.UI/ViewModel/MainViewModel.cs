using Abp.Dependency;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Wing.ABPMetroWPF.UI.Theme;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, ISingletonDependency
	{
		public static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
		public static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();
		public ObservableCollection<MenuItem> Menu => AppMenu;
		public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

		public MainViewModel()
		{
			// Build the menus
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.SitemapSolid }, Text = "组织机构", NavigationDestination = new Uri("View/OrganizationUnitsPage.xaml", UriKind.RelativeOrAbsolute) });
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.TagsSolid }, Text = "角色", NavigationDestination = new Uri("View/RolesPage.xaml", UriKind.RelativeOrAbsolute) });
			this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid }, Text = "用户", NavigationDestination = new Uri("View/UsersPage.xaml", UriKind.RelativeOrAbsolute) });

			this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid }, Text = "设置", NavigationDestination = new Uri("View/SettingsPage.xaml", UriKind.RelativeOrAbsolute) });
			this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircleSolid }, Text = "关于", NavigationDestination = new Uri("View/AboutPage.xaml", UriKind.RelativeOrAbsolute) });

			// create accent color menu items for the demo
			this.AccentColors = ThemeManager.Accents
											.Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
											.ToList();

			// create metro theme color menu items for the demo
			this.AppThemes = ThemeManager.AppThemes
										   .Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
										   .ToList();

		}

		public List<AccentColorMenuData> AccentColors { get; set; }
		public List<AppThemeMenuData> AppThemes { get; set; }

	}
}
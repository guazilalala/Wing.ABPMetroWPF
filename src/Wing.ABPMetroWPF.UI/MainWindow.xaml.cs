using Abp.Dependency;
using MahApps.Metro.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Wing.ABPMetroWPF.UI.View;

namespace Wing.ABPMetroWPF.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow, ISingletonDependency
	{

        public MainWindow()
        {
            InitializeComponent();
			// Navigate to the home page.
			Navigation.Navigation.Frame = new Frame(); //SplitViewFrame;
			Navigation.Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;
			this.Loaded += (sender, args) => Navigation.Navigation.Navigate(new MainPage());
		}

		private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
		{
			HamburgerMenuControl.Content = e.Content;
			GoBackButton.Visibility = Navigation.Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
		}

		private void GoBack_OnClick(object sender, RoutedEventArgs e)
		{
			Navigation.Navigation.GoBack();
		}

		private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
		{
			var menuItem = e.ClickedItem as ViewModel.MenuItem;
			if (menuItem != null && menuItem.IsNavigation)
			{
				Navigation.Navigation.Navigate(menuItem.NavigationDestination);
			}
		}

		private void ThemeButton_Click(object sender, RoutedEventArgs e)
		{
			if (themeFlyout.IsOpen)
			{
				themeFlyout.IsOpen = false;
			}
			else
			{
				themeFlyout.IsOpen = true;
			}
		}
	}
}

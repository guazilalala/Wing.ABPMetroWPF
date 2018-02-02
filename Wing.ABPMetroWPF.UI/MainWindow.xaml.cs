using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Abp.Dependency;
using MahApps.Metro.Controls;
using Wing.ABPMetroWPF.People;
using Wing.ABPMetroWPF.People.Dto;
using Wing.ABPMetroWPF.UI.View;
using Wing.ABPMetroWPF.UI.ViewModel;

namespace Wing.ABPMetroWPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, ISingletonDependency
	{
        private readonly IPersonAppService _personAppService;

        public MainWindow(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
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

		private async void LoadAllPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadAllPeopleAsync();
        }

		private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
		{
			var menuItem = e.ClickedItem as ViewModel.MenuItem;
			if (menuItem != null && menuItem.IsNavigation)
			{
				Navigation.Navigation.Navigate(menuItem.NavigationDestination);
			}
		}

		private async Task LoadAllPeopleAsync()
        {
            //PeopleList.Items.Clear();
            //var result = await _personAppService.GetAllPeopleAsync();
            //foreach (var person in result.People)
            //{
            //    PeopleList.Items.Add(person.Name);
            //}
        }

        private async void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _personAppService.AddNewPerson(new AddNewPersonInput
                {
                    //Name = NameTextBox.Text
                });

                await LoadAllPeopleAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

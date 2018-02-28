/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Wing.ABPMetroWPF.UI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using Wing.ABPMetroWPF.UI.ViewModel.Account;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
        {
		}

		public MainViewModel Main
        {
            get
            {
				return IocManager.Instance.Resolve<MainViewModel>();
			}
		}

		public AccountViewModel Account
		{
			get
			{
				return IocManager.Instance.Resolve<AccountViewModel>();
			}
		}

		public UsersViewModel Users
		{
			get
			{
				return IocManager.Instance.Resolve<UsersViewModel>();
			}
		}

		public AddUserViewModel AddUser
		{
			get
			{
				return IocManager.Instance.Resolve<AddUserViewModel>();
			}
		}

		public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
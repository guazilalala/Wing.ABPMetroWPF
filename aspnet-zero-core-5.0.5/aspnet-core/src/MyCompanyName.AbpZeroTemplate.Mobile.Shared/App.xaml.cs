using System;
using Abp.Dependency;
using MyCompanyName.AbpZeroTemplate.Core.Dependency;
using MyCompanyName.AbpZeroTemplate.Localization.Resources;
using MyCompanyName.AbpZeroTemplate.Services.Navigation;
using MyCompanyName.AbpZeroTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace MyCompanyName.AbpZeroTemplate
{
    public partial class App : Application, ISingletonDependency
    {
        public App()
        {
            InitializeComponent();
        }

        public static Action ExitApplication;

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform == Device.iOS)
            {
                SetInitialScreenForIos();
                await UserConfigurationManager.GetIfNeedsAsync();
            }

            await DependencyResolver.Resolve<INavigationService>().InitializeAsync();
            OnResume();
        }

        private void SetInitialScreenForIos()
        {
            MainPage = new ContentPage
            {
                BackgroundColor = (Color)Current.Resources["LoginBackgroundColor"],
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new ActivityIndicator
                        {
                            IsRunning = true,
                            Color = Color.White
                        },
                        new Label
                        {
                            Text = LocalTranslation.Initializing,
                            TextColor = Color.White,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        }
                    }
                }
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
    }
}

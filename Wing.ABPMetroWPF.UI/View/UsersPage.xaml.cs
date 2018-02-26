using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wing.ABPMetroWPF.UI.View
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

			Messenger.Default.Register<NotificationMessageAction<bool>>(this,"OpenAddUserView",msg => 
			{
				var addUserView = new AddUser();
				msg.Execute(addUserView.ShowDialog());			
			});

			this.Unloaded += (s,e) => Messenger.Default.Unregister(this);
        }
	}
}

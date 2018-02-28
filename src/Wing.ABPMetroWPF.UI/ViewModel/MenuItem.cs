using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;

namespace Wing.ABPMetroWPF.UI.ViewModel
{
	public class MenuItem : ViewModelBase
    {
        private object _icon;
        private string _text;
        private bool _isEnabled = true;
        private RelayCommand _command;
        private Uri _navigationDestination;
		private List<MenuItem> _childern;

		public object Icon
        {
            get { return this._icon; }
            set
			{
				_icon = value;
				RaisePropertyChanged(() => Icon);
			}
        }

        public string Text
        {
            get { return this._text; }
            set { _text = value;
				RaisePropertyChanged(()=>Text);
			}
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set
			{
				_isEnabled = value;
				RaisePropertyChanged(() => IsEnabled);
			}
        }

        public RelayCommand Command
        {
            get { return this._command; }
			set { _command = value; }
        }

        public Uri NavigationDestination
        {
            get { return this._navigationDestination; }
            set { _navigationDestination = value;
				RaisePropertyChanged(()=> NavigationDestination);
			}
        }

        public bool IsNavigation => this._navigationDestination != null;

		public List<MenuItem> Childern
		{
			get
			{
				return _childern ;
			}
			set
			{
				_childern = value;
				RaisePropertyChanged(() => Childern);
			}
		}
    }
}
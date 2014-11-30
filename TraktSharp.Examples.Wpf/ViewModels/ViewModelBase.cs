using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TraktSharp.Examples.ViewModels {

	public class ViewModelBase : INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
			if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}

	}

}
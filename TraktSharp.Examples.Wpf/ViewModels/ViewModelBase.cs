using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TraktSharp.Examples.Wpf.ViewModels {

	internal abstract class ViewModelBase : INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}

}
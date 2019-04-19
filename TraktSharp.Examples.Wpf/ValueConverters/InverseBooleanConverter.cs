﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace TraktSharp.Examples.Wpf.ValueConverters {

	[ValueConversion(typeof(bool), typeof(bool))]
	internal class InverseBooleanConverter : IValueConverter {

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (targetType != typeof(bool)) { throw new InvalidOperationException("The target must be a boolean"); }
			return value != null && !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
			=> throw new NotSupportedException();

	}

}
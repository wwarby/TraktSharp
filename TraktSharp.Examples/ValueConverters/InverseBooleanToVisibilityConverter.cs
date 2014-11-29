﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace TraktSharp.Examples.ValueConverters {

	[ValueConversion(typeof(bool), typeof(bool))]
	public class InverseBooleanToVisibilityConverter : IValueConverter {

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (targetType != typeof(Visibility)) { throw new InvalidOperationException("The target must be a Visibility"); }
			return (bool)value ? Visibility.Hidden : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }

	}

}
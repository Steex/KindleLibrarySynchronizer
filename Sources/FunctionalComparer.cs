﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text;
using System.Drawing.Imaging;

namespace KindleLibrarySynchronizer
{
	public class FunctionalComparer<T> : IComparer<T>
	{
		private Func<T, T, int> comparer;

		public FunctionalComparer(Func<T, T, int> comparer)
		{
			this.comparer = comparer;
		}

		public static IComparer<T> Create(Func<T, T, int> comparer)
		{
			return new FunctionalComparer<T>(comparer);
		}

		public int Compare(T x, T y)
		{
			return comparer(x, y);
		}
	}
}

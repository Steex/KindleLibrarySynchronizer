using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text;
using System.Drawing.Imaging;

namespace KindleLibrarySynchronizer
{
	public static class Logger
	{
		public delegate void ClearHandler();
		public delegate void WriteHandler(string message);

		public static event ClearHandler OnClear;
		public static event WriteHandler OnWrite;


		private static object locker = new object();


		public static void WriteLine(string message)
		{
			PerformWrite(message + "\r\n");
		}

		public static void WriteLine(string message, params object[] args)
		{
			PerformWrite(string.Format(message + "\r\n", args));
		}

		public static void Write(string message)
		{
			PerformWrite(message);
		}

		public static void Write(string message, params object[] args)
		{
			PerformWrite(string.Format(message, args));
		}


		private static void PerformWrite(string message)
		{
			lock (locker)
			{
				if (OnWrite != null)
				{
					OnWrite(message);
				}
			}
		}


		public static void Clear()
		{
			lock (locker)
			{
				if (OnClear != null)
				{
					OnClear();
				}
			}
		}
	}
}

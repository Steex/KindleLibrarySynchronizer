using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace KindleLibrarySynchronizer
{
	public static class Globals
	{
		private static readonly string registryRootName = @"Software\SteexSoft\KindleLibrarySynchronizer";

		public static readonly int SeriesNameMaxLength = 10; // longer strings will be abbreviated

		public static List<LibraryInfo> Libraries { get; private set; }


		static Globals()
		{
			Libraries = new List<LibraryInfo>();
		}


		public static void Load()
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				settingsRoot.Close();
			}
		}

		public static void Save()
		{
			try
			{
				RegistryKey settingsRoot = Registry.CurrentUser.CreateSubKey(registryRootName);
				if (settingsRoot != null)
				{
					settingsRoot.Close();
				}
			}
			catch
			{
			}
		}
	}
}

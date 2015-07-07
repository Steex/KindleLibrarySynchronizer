using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
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

			/*LibraryInfo library = new LibraryInfo();

			library.Name = "Test Library";
			library.SourceRoot = "E:\\Library";
			library.TargetRoot = "E:\\Library-Kindle";
			library.SkippedFiles.Add("Разное\\Эти странные…\\");
			library.SkippedFiles.Add("Художественная\\_Не оформленное\\");
			library.SkippedFiles.Add("Художественная\\_Периодика\\");

			Libraries.Add(library);/**/
		}


		public static void Load()
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				// Libraries.
				RegistryKey librariesKey = settingsRoot.OpenSubKey("Libraries");
				if (librariesKey != null)
				{
					foreach (string libraryKeyName in librariesKey.GetSubKeyNames())
					{
						RegistryKey libraryKey = librariesKey.OpenSubKey(libraryKeyName);
						if (libraryKey != null)
						{
							LibraryInfo library = new LibraryInfo();

							library.Name = Utils.ReadRegistryValue(libraryKey, null, libraryKeyName);
							library.SourceRoot = Utils.ReadRegistryValue(libraryKey, "Source Root", "");
							library.TargetRoot = Utils.ReadRegistryValue(libraryKey, "Target Root", "");

							foreach (string skippedFileValue in libraryKey.GetValueNames().Where(n => n.StartsWith("Skipped Files ")))
							{
								string skippedFile = Utils.ReadRegistryValue(libraryKey, skippedFileValue, "");
								if (!string.IsNullOrEmpty(skippedFile))
								{
									library.SkippedFiles.Add(skippedFile);
								}
							}

							Libraries.Add(library);

							libraryKey.Close();
						}
					}
				}

				// All done.
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
					// Libraries.
					settingsRoot.DeleteSubKeyTree("Libraries", false);

					RegistryKey librariesKey = settingsRoot.CreateSubKey("Libraries");
					if (librariesKey != null)
					{
						for (int i = 0; i < Libraries.Count; ++i)
						{
							RegistryKey libraryKey = librariesKey.CreateSubKey((i + 1).ToString());
							if (libraryKey != null)
							{
								Utils.WriteRegistryValue(libraryKey, null, Libraries[i].Name);
								Utils.WriteRegistryValue(libraryKey, "Source Root", Libraries[i].SourceRoot);
								Utils.WriteRegistryValue(libraryKey, "Target Root", Libraries[i].TargetRoot);

								for (int s = 0; s < Libraries[i].SkippedFiles.Count; ++s)
								{
									Utils.WriteRegistryValue(libraryKey, "Skipped Files " + (s + 1).ToString(), Libraries[i].SkippedFiles[s]);
								}

								libraryKey.Close();
							}
						}
					}

					// All done.
					settingsRoot.Close();
				}
			}
			catch
			{
			}
		}
	}
}

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
	public class Config
	{
		/*
		Test Library
		E:\Library
		E:\Library-Kindle
		Разное\Эти странные…\
		Художественная\_Не оформленное\
		Художественная\_Периодика\
		*/



		private readonly string registryRootName = @"Software\SteexSoft\KindleLibrarySynchronizer";
		private readonly string defaultStylesheet = @"data\stylesheet.json";

		public readonly int SeriesNameMaxLength = 10; // longer strings will be abbreviated


		// Libraries.
		public List<LibraryInfo> Libraries { get; private set; }

		// Converter.
		public String ConverterDirectory { get; set; }

		public String ConverterDefaultStylesheet { get { return defaultStylesheet; } }
		public String ConverterUserStylesheet { get; set; }
		public String ConverterStylesheet
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(ConverterUserStylesheet))
				{
					return ConverterUserStylesheet;
				}
				else
				{
					return ConverterDefaultStylesheet;
				}
			}
		}

		// The config used by application.
		public static Config Main { get; private set; }


		static Config()
		{
			Main = new Config();
		}

		private Config()
		{
			Libraries = new List<LibraryInfo>();

			ConverterDirectory = "";
			ConverterUserStylesheet = "";
		}

		public Config(Config right)
		{
			// Libraries.
			Libraries = new List<LibraryInfo>();

			foreach (LibraryInfo library in right.Libraries)
			{
				Libraries.Add(new LibraryInfo(library));
			}

			// Converter.
			ConverterDirectory = right.ConverterDirectory;
			ConverterUserStylesheet = right.ConverterUserStylesheet;
		}


		public static void SetMain(Config config)
		{
			Main = new Config(config);
		}


		public void Load()
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

							foreach (string ignoredFileValue in libraryKey.GetValueNames().Where(n => n.StartsWith("Ignored Files ")))
							{
								string ignoredFile = Utils.ReadRegistryValue(libraryKey, ignoredFileValue, "");
								if (!string.IsNullOrEmpty(ignoredFile))
								{
									library.IgnoredFiles.Add(ignoredFile);
								}
							}

							Libraries.Add(library);

							libraryKey.Close();
						}
					}
				}

				// Converter.
				RegistryKey converterKey = settingsRoot.OpenSubKey("Converter");
				if (converterKey != null)
				{
					ConverterDirectory = Utils.ReadRegistryValue(converterKey, "Directory", ConverterDirectory);
					ConverterUserStylesheet = Utils.ReadRegistryValue(converterKey, "User Stylesheet", ConverterUserStylesheet);
				}

				// All done.
				settingsRoot.Close();
			}
		}

		public void Save()
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

								for (int s = 0; s < Libraries[i].IgnoredFiles.Count; ++s)
								{
									Utils.WriteRegistryValue(libraryKey, "Ignored Files " + (s + 1).ToString(), Libraries[i].IgnoredFiles[s]);
								}

								libraryKey.Close();
							}
						}
					}

					// Converter.
					RegistryKey converterKey = settingsRoot.CreateSubKey("Converter");
					if (converterKey != null)
					{
						Utils.WriteRegistryValue(converterKey, "Directory", ConverterDirectory);
						Utils.WriteRegistryValue(converterKey, "User Stylesheet", ConverterUserStylesheet);
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

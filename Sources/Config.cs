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



		private static readonly string registryRootName = @"Software\SteexSoft\KindleLibrarySynchronizer";
		private static readonly string defaultStylesheet = @"data\stylesheet.json";
		private static readonly string converterExecutable = @"lib\fb2pdf.jar";

		public readonly int SeriesNameMaxLength = 10; // longer strings will be abbreviated


		// Libraries.
		public List<LibraryInfo> Libraries { get; private set; }
		public string CurrentLibrary { get; set; }

		// Converter.
		public String ConverterDirectory { get; set; }

		public String ConverterExecutable { get { return converterExecutable; } }

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

		public Config Clone()
		{
			Config copy = new Config();

			copy.Libraries = new List<LibraryInfo>(Libraries.Select(l => l.Clone()));
			copy.CurrentLibrary = CurrentLibrary;
			copy.ConverterDirectory = ConverterDirectory;
			copy.ConverterUserStylesheet = ConverterUserStylesheet;

			return copy;
		}


		public static void SetMain(Config config)
		{
			Main = config.Clone();
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
					CurrentLibrary = Utils.ReadRegistryValue(librariesKey, "Current Library", "");

					foreach (string libraryKeyName in librariesKey.GetSubKeyNames())
					{
						RegistryKey libraryKey = librariesKey.OpenSubKey(libraryKeyName);
						if (libraryKey != null)
						{
							LibraryInfo library = new LibraryInfo();

							library.Name = Utils.ReadRegistryValue(libraryKey, null, libraryKeyName);
							library.SourceRoot = Utils.ReadRegistryValue(libraryKey, "Source Root", "");
							library.TargetRoot = Utils.ReadRegistryValue(libraryKey, "Target Root", "");
							library.IgnoredFiles = Utils.ReadRegistryList(libraryKey, "Ignored Files ").ToList();
							library.MainStylesheet = Utils.ReadRegistryValue(libraryKey, "Main Stylesheet", "");
							library.CustomStylesheets = Utils.DeserializeListFromRegistry<LibraryInfo.CustomStylesheet>(libraryKey, "Custom Stylesheet ").ToList();

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
						Utils.WriteRegistryValue(librariesKey, "Current Library", CurrentLibrary);

						for (int i = 0; i < Libraries.Count; ++i)
						{
							RegistryKey libraryKey = librariesKey.CreateSubKey((i + 1).ToString());
							if (libraryKey != null)
							{
								Utils.WriteRegistryValue(libraryKey, null, Libraries[i].Name);
								Utils.WriteRegistryValue(libraryKey, "Source Root", Libraries[i].SourceRoot);
								Utils.WriteRegistryValue(libraryKey, "Target Root", Libraries[i].TargetRoot);
								Utils.WriteRegistryList(libraryKey, "Ignored Files ", Libraries[i].IgnoredFiles);
								Utils.WriteRegistryValue(libraryKey, "Main Stylesheet", Libraries[i].MainStylesheet);
								Utils.SerializeListToRegistry(libraryKey, "Custom Stylesheet ", Libraries[i].CustomStylesheets);

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

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
		public string ConverterDirectory { get; set; }
		public string ConverterExecutable { get { return converterExecutable; } }
		public string ConverterDefaultStylesheet { get { return defaultStylesheet; } }
		public string ConverterUserStylesheet { get; set; }
		public string ConverterStylesheet
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

		// Book display.
		public bool ShowActualBooks { get; set; }
		public bool ShowNewBooks { get; set; }
		public bool ShowChangedBooks { get; set; }
		public bool ShowDeletedBooks { get; set; }
		public bool ShowIgnoredBooks { get; set; }

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

			ShowActualBooks = true;
			ShowNewBooks = true;
			ShowChangedBooks = true;
			ShowDeletedBooks = true;
			ShowIgnoredBooks = false;
		}

		public Config Clone()
		{
			Config copy = new Config();

			copy.Libraries = new List<LibraryInfo>(Libraries.Select(l => l.Clone()));
			copy.CurrentLibrary = CurrentLibrary;
			copy.ConverterDirectory = ConverterDirectory;
			copy.ConverterUserStylesheet = ConverterUserStylesheet;

			copy.ShowActualBooks = ShowActualBooks;
			copy.ShowNewBooks = ShowNewBooks;
			copy.ShowChangedBooks = ShowChangedBooks;
			copy.ShowDeletedBooks = ShowDeletedBooks;
			copy.ShowIgnoredBooks = ShowIgnoredBooks;

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

				// UI.
				RegistryKey booksKey = settingsRoot.OpenSubKey("Books");
				if (booksKey != null)
				{
					ShowActualBooks = Utils.ReadRegistryValue(booksKey, "Show Actual Books", ShowActualBooks);
					ShowNewBooks = Utils.ReadRegistryValue(booksKey, "Show New Books", ShowNewBooks);
					ShowChangedBooks = Utils.ReadRegistryValue(booksKey, "Show Changed Books", ShowChangedBooks);
					ShowDeletedBooks = Utils.ReadRegistryValue(booksKey, "Show Deleted Books", ShowDeletedBooks);
					ShowIgnoredBooks = Utils.ReadRegistryValue(booksKey, "Show Ignored Books", ShowIgnoredBooks);
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

					// UI.
					RegistryKey booksKey = settingsRoot.CreateSubKey("Books");
					if (booksKey != null)
					{
						Utils.WriteRegistryValue(booksKey, "Show Actual Books", ShowActualBooks);
						Utils.WriteRegistryValue(booksKey, "Show New Books", ShowNewBooks);
						Utils.WriteRegistryValue(booksKey, "Show Changed Books", ShowChangedBooks);
						Utils.WriteRegistryValue(booksKey, "Show Deleted Books", ShowDeletedBooks);
						Utils.WriteRegistryValue(booksKey, "Show Ignored Books", ShowIgnoredBooks);
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

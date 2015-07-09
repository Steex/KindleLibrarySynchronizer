using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public class LibraryInfo
	{
		public struct CustomStylesheet
		{
			public string Mask;
			public string Stylesheet;
		}

		public string Name { get; set; }
		public string SourceRoot { get; set; }
		public string TargetRoot { get; set; }
		public List<string> IgnoredFiles { get; private set; }
		public string MainStylesheet { get; set; }
		public List<CustomStylesheet> CustomStylesheets { get; set; }

		public LibraryInfo()
		{
			Name = "";
			SourceRoot = "";
			TargetRoot = "";
			IgnoredFiles = new List<string>();
			MainStylesheet = "";
			CustomStylesheets = new List<CustomStylesheet>();
		}

		public LibraryInfo(LibraryInfo right)
		{
			Name = right.Name;
			SourceRoot = right.SourceRoot;
			TargetRoot = right.TargetRoot;
			IgnoredFiles = new List<string>(right.IgnoredFiles);
			MainStylesheet = right.MainStylesheet;
			CustomStylesheets = new List<CustomStylesheet>(right.CustomStylesheets);
		}


		public string GetStylesheet(string bookPath)
		{
			int stylesheetIndex = CustomStylesheets.FindIndex(s => bookPath.StartsWith(s.Mask, StringComparison.CurrentCultureIgnoreCase));

			return (stylesheetIndex != -1) ? CustomStylesheets[stylesheetIndex].Stylesheet : MainStylesheet;
		}

	}

}

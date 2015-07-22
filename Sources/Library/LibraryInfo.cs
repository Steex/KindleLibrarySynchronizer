using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public class LibraryInfo
	{
		public class CustomStylesheet
		{
			public string Mask { get; set; }
			public string Stylesheet { get; set; }

			public CustomStylesheet Clone()
			{
				return (CustomStylesheet)MemberwiseClone();
			}
		}

		public string Name { get; set; }
		public string SourceRoot { get; set; }
		public string TargetRoot { get; set; }
		public List<string> IgnoredFiles { get; set; }
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

		public LibraryInfo Clone()
		{
			LibraryInfo copy = new LibraryInfo();

			copy.Name = Name;
			copy.SourceRoot = SourceRoot;
			copy.TargetRoot = TargetRoot;
			copy.IgnoredFiles = new List<string>(IgnoredFiles);
			copy.MainStylesheet = MainStylesheet;
			copy.CustomStylesheets = new List<CustomStylesheet>(CustomStylesheets.Select(s => s.Clone()));

			return copy;
		}


		public string GetStylesheet(string bookPath)
		{
			int stylesheetIndex = CustomStylesheets.FindIndex(s => bookPath.StartsWith(s.Mask, StringComparison.CurrentCultureIgnoreCase));

			return (stylesheetIndex != -1) ? CustomStylesheets[stylesheetIndex].Stylesheet : MainStylesheet;
		}

	}

}

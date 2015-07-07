using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public class LibraryInfo
	{
		public string Name { get; set; }
		public string SourceRoot { get; set; }
		public string TargetRoot { get; set; }
		public List<string> SkippedFiles { get; private set; }

		public LibraryInfo()
		{
			SkippedFiles = new List<string>();
		}

		public LibraryInfo(LibraryInfo right)
		{
			Name = right.Name;
			SourceRoot = right.SourceRoot;
			TargetRoot = right.TargetRoot;
			SkippedFiles = new List<string>(right.SkippedFiles);
		}

	}

}

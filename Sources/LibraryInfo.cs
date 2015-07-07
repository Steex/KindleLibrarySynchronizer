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
	}

}

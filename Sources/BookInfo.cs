using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace KindleLibrarySynchronizer
{
	public enum BookState
	{
		Actual,
		New,
		Changed,
		Deleted,
	}


	public class BookInfo
	{
		public string SourcePath { get; private set; }
		public string TargetPath { get; private set; }
		public DateTime SourceDate { get; private set; }
		public DateTime TargetDate { get; private set; }
		public BookState State { get; private set; }

		public BookInfo(string sourcePath, string targetPath)
		{
			// Check if source and target file are exists.
			bool sourceExists = File.Exists(sourcePath);
			bool targetExists = File.Exists(targetPath);

			if (!sourceExists && !targetExists)
			{
				throw new FileNotFoundException(
					"Neither source nor target files are not found.\r\n" +
					"Source path: " + sourcePath + "\r\n" + 
					"Target path: " + targetPath + "\r\n");
			}

			// Set the paths and change times.
			SourcePath = sourcePath;
			TargetPath = targetPath;

			SourceDate = sourceExists ? File.GetLastWriteTimeUtc(sourcePath) : DateTime.MinValue;
			TargetDate = targetExists ? File.GetLastWriteTimeUtc(targetPath) : DateTime.MinValue;

			// Determine the state.
			if (!sourceExists)
			{
				State = BookState.Deleted;
			}
			else if (!targetExists)
			{
				State = BookState.New;
			}
			else if (SourceDate > TargetDate)
			{
				State = BookState.Changed;
			}
			else
			{
				State = BookState.Actual;
			}
		}
	}

}

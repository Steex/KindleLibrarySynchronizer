using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace KindleLibrarySynchronizer
{
	public static class BookOperations
	{
		public static BackgroundWorker CreateConverter(/*IEnumerable<BookInfo> books*/)
		{
			BackgroundWorker worker = new BackgroundWorker();

			worker.WorkerSupportsCancellation = true;
			worker.WorkerReportsProgress = true;
			worker.DoWork += ConverterWorker_DoWork;

			return worker;
		}

		private static void ConverterWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = (BackgroundWorker)sender;
			IEnumerable<BookInfo> books = (IEnumerable<BookInfo>)e.Argument;
			int bookCount = books.Count();
			int convertedCount = 0;

			foreach (BookInfo book in books)
			{
				// Report progress before an operation so we can inform UI about a book currently converted.
				worker.ReportProgress((int)((float)convertedCount / bookCount * 100), book);

				string errorMessage = null;

				// Convert the book.
				try
				{
					using (Process converter = new Process())
					{
						converter.StartInfo.FileName = "find";
						converter.StartInfo.Arguments = Path.GetDirectoryName(book.SourcePath);
						converter.StartInfo.UseShellExecute = false;
						converter.StartInfo.CreateNoWindow = true;
						converter.StartInfo.RedirectStandardOutput = true;
						converter.StartInfo.RedirectStandardError = true;
						converter.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(1251);
						converter.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(1251);
						converter.Start();

						string output = converter.StandardOutput.ReadToEnd();
						string errors = converter.StandardError.ReadToEnd();

						converter.WaitForExit();
						if (converter.ExitCode != 0)
						{
							errorMessage = errors;
						}
					}
				}
				catch (Exception ex)
				{
					errorMessage = "Exception: " + ex.Message;
				}

				// Report progress after the operation so we can inform UI about the result.
				worker.ReportProgress((int)((float)convertedCount / bookCount * 100), errorMessage);

				// Count the operation progress.
				convertedCount += 1;
			}

			// Report the final progress.
			worker.ReportProgress(100, null);
		}

	}
}

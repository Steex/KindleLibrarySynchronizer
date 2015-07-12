using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

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

				try
				{
					// If the target book exists, delete it.
					if (File.Exists(book.TargetPath))
					{
						File.Delete(book.TargetPath);
					}

					// Convert the book.
					using (Process converter = new Process())
					{
						converter.StartInfo.FileName = "java";
						converter.StartInfo.Arguments = string.Format("-Xmx512m -jar \"{0}\" -l false -s \"{1}\" \"{2}\" \"{3}\"",
							Path.Combine(Config.Main.ConverterDirectory, Config.Main.ConverterExecutable),
							Path.Combine(Config.Main.ConverterDirectory, Config.Main.ConverterStylesheet),
							book.SourcePath,
							book.TargetPath);
						converter.StartInfo.UseShellExecute = false;
						converter.StartInfo.CreateNoWindow = true;
						converter.StartInfo.RedirectStandardOutput = true;
						converter.StartInfo.RedirectStandardError = true;
						converter.StartInfo.StandardOutputEncoding = Encoding.Default;
						converter.StartInfo.StandardErrorEncoding = Encoding.Default;

						StringBuilder output = new StringBuilder();
						StringBuilder errors = new StringBuilder();

						using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
						using (AutoResetEvent errorsWaitHandle = new AutoResetEvent(false))
						{
							converter.OutputDataReceived += (evSenver, evArgs) =>
							{
								if (evArgs.Data == null)
								{
									outputWaitHandle.Set();
								}
								else
								{
									output.AppendLine(evArgs.Data);
								}
							};
							converter.ErrorDataReceived += (evSenver, evArgs) =>
							{
								if (evArgs.Data == null)
								{
									errorsWaitHandle.Set();
								}
								else
								{
									errors.AppendLine(evArgs.Data);
								}
							};

							converter.Start();

							converter.BeginOutputReadLine();
							converter.BeginErrorReadLine();

							if (converter.WaitForExit(60000) &&
								outputWaitHandle.WaitOne(60000) &&
								errorsWaitHandle.WaitOne(60000))
							{
								if (converter.ExitCode != 0)
								{
									errorMessage = errors.ToString();
								}
							}
							else
							{
								errorMessage = "Timeout";
							}
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

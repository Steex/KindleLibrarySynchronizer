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
		public class OperationData
		{
			public string OperationName { get; private set; }
			public IEnumerable<BookInfo> Books { get; private set; }

			public OperationData(string operationName, IEnumerable<BookInfo> books)
			{
				OperationName = operationName;
				Books = books;
			}
		}

		public class StepInfo
		{
			public BookInfo Book { get; private set; }

			public StepInfo(BookInfo book)
			{
				Book = book;
			}
		}

		public class StepResult
		{
			public bool Succeeded { get; private set; }
			public string ErrorText { get; private set; }

			public StepResult(bool succeded, string errorText)
			{
				Succeeded = succeded;
				ErrorText = errorText;
			}
		}


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
			OperationData data = (OperationData)e.Argument;
			int bookCount = data.Books.Count();
			int convertedCount = 0;

			foreach (BookInfo book in data.Books)
			{
				// Report progress before an operation so we can inform UI about a book currently converted.
				worker.ReportProgress(
					(int)((float)convertedCount / bookCount * 100),
					new StepInfo(book));

				// Start operation.
				string tempFilePath = null;
				string errorMessage = null;

				try
				{
					// Create a temporary file to convert to.
					tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

					// Convert the book to the temporary file.
					ConvertBook(book.SourcePath, tempFilePath);

					// Move the temporary file to the target path.
					Utils.MoveFile(tempFilePath, book.TargetPath);

				}
				catch (Exception ex)
				{
					errorMessage = ex.Message;
				}
				finally
				{
					if (tempFilePath != null &&
						File.Exists(tempFilePath))
					{
						File.Delete(tempFilePath);
					}
				}

				// Report progress after the operation so we can inform UI about the result.
				worker.ReportProgress(
					(int)((float)convertedCount / bookCount * 100),
					new StepResult(errorMessage == null, errorMessage));

				// Count the operation progress.
				convertedCount += 1;

				// Check for cancellation.
				if (worker.CancellationPending)
				{
					break;
				}
			}

			// Report the final progress.
			worker.ReportProgress(100, null);
		}

		private static void ConvertBook(string sourcePath, string targetPath)
		{
			using (Process converter = new Process())
			{
				converter.StartInfo.FileName = "java";
				converter.StartInfo.Arguments = string.Format("-Xmx512m -jar \"{0}\" -l false -s \"{1}\" \"{2}\" \"{3}\"",
					Path.Combine(Config.Main.ConverterDirectory, Config.Main.ConverterExecutable),
					Path.Combine(Config.Main.ConverterDirectory, Config.Main.ConverterStylesheet),
					sourcePath,
					targetPath);
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
							throw new Exception(errors.ToString());
						}
					}
					else
					{
						throw new TimeoutException("Converter is not responding. Skip the current book.");
					}
				}
			}
		}
	}
}

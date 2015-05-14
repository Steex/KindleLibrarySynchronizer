using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aliasworlds;

namespace KindleLibrarySynchronizer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonCompare_Click(object sender, EventArgs e)
		{
			//MusicComparer comparer = new MusicComparer(textMusicSourceRoot.Text, textMusicTargetRoot.Text, textPlaylists.Lines);

			SortedSet<string> sourceFiles = new SortedSet<string>();
			SortedSet<string> targetFiles = new SortedSet<string>();

			List<string> skippedFiles = new List<string>();
			skippedFiles.Add("Разное\\Эти странные…\\");
			skippedFiles.Add("Художественная\\_Не оформленное\\");
			skippedFiles.Add("Художественная\\_Периодика\\");


			/*foreach (string playlistPath in textPlaylists.Lines)
			{
				IPlaylistReader playlist = PlaylistReaderFactory.CreateReader(playlistPath);
				if (playlist != null)
				{
					foreach (string song in playlist.Songs)
					{
						sourceSongs.Add(song);
					}
				}
			}/**/

			foreach (string sourceFile in Directory.GetFiles(textSourceRoot.Text, "*.fb2", SearchOption.AllDirectories))
			{
				string basePath = Utils.RemoveExtension(Utils.GetRelativePath(sourceFile, textSourceRoot.Text));

				if (!skippedFiles.Any(f => basePath.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)))
				{
					sourceFiles.Add(basePath);
				}
			}

			foreach (string targetFile in Directory.GetFiles(textTargetRoot.Text, "*.fb2", SearchOption.AllDirectories))
			{
				string basePath = Utils.RemoveExtension(Utils.GetRelativePath(targetFile, textTargetRoot.Text));

				if (!skippedFiles.Any(f => basePath.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)))
				{
					sourceFiles.Add(basePath);
				}
			}

			List<BookInfo> books = new List<BookInfo>();

			foreach (string sourceFile in sourceFiles)
			{
				string sourceBookPath = Path.Combine(textSourceRoot.Text, sourceFile) + ".fb2";
				string targetBookPath = Path.Combine(textTargetRoot.Text, sourceFile) + ".fb2";
				books.Add(new BookInfo(sourceBookPath, targetBookPath));
			}

			// Report.
			textLog.Clear();

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Changed)
				{
					textLog.AppendText(string.Format("Changed: {0}\r\n", book.SourcePath));
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Deleted)
				{
					textLog.AppendText(string.Format("Deleted: {0}\r\n", book.SourcePath));
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.New)
				{
					textLog.AppendText(string.Format("New: {0}\r\n", book.SourcePath));
				}
			}

			textLog.AppendText("---");
		}

	}

}

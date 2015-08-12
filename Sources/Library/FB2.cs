using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace KindleLibrarySynchronizer
{
	public class FB2
	{
		public struct Author
		{
			public string FirstName;
			public string MiddleName;
			public string LastName;
			public string NickName;

			public Author(XmlElement xml)
			{
				FirstName = xml["first-name"] != null ? xml["first-name"].InnerText.Trim() : "";
				MiddleName = xml["middle-name"] != null ? xml["middle-name"].InnerText.Trim() : "";
				LastName = xml["last-name"] != null ? xml["last-name"].InnerText.Trim() : "";
				NickName = xml["nickname"] != null ? xml["nickname"].InnerText.Trim() : "";
			}
		}


		public List<Author> Authors { get; private set; }
		public string Title { get; private set; }
		public string SeriesName { get; private set; }
		public int SeriesNumber { get; private set; }
		public string PdfTitle { get; private set; }


		public FB2(string path)
		{
			// Load the book file.
			XmlDocument xml = new XmlDocument();
			xml.Load(path);

			// Add the namespace.
			XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
			ns.AddNamespace("fb", xml.DocumentElement.NamespaceURI);

			// Read the book info.
			ReadAuthors(xml, ns);
			ReadTitle(xml, ns);
			ReadSeriesInfo(xml, ns, path);
			BuildPdfTitle();
		}


		private void ReadAuthors(XmlDocument xml, XmlNamespaceManager ns)
		{
			Authors = new List<Author>();
			foreach (XmlElement authorXml in xml.SelectNodes("/fb:FictionBook/fb:description/fb:title-info/fb:author", ns))
			{
				Authors.Add(new Author(authorXml));
			}
		}

		private void ReadTitle(XmlDocument xml, XmlNamespaceManager ns)
		{
			// Read the book title.
			XmlNode titleNode = xml.SelectSingleNode("/fb:FictionBook/fb:description/fb:title-info/fb:book-title", ns);
			if (titleNode != null)
			{
				Title = titleNode.InnerText.Trim();
			}
			else
			{
				throw new Exception("The title info is not found");
			}
		}

		private void ReadSeriesInfo(XmlDocument xml, XmlNamespaceManager ns, string path)
		{
			// Read the sequence info.
			SeriesName = "";
			SeriesNumber = 0;

			XmlElement seriesNode = xml.SelectSingleNode("/fb:FictionBook/fb:description/fb:title-info/fb:sequence", ns) as XmlElement;
			if (seriesNode != null &&
				!string.IsNullOrEmpty(seriesNode.GetAttribute("name")) &&
				!string.IsNullOrEmpty(seriesNode.GetAttribute("number")))
			{
				SeriesName = seriesNode.GetAttribute("name");
				SeriesNumber = int.Parse(seriesNode.GetAttribute("number"));
			}
		}

		private void BuildPdfTitle()
		{
			// Build the PDF title.
			PdfTitle = "";

			// Append the series prefix.
			if (!string.IsNullOrEmpty(SeriesName) &&
				SeriesNumber > 0)
			{
				string seriesPrefix;
				if (SeriesName.Length < Config.Main.SeriesNameMaxLength &&
					!SeriesName.Contains(' '))
				{
					seriesPrefix = SeriesName;
				}
				else
				{
					seriesPrefix = Utils.AbbreviateString(SeriesName);
				}

				PdfTitle += string.Format("{0}-{1}. ", seriesPrefix, SeriesNumber);
			}

			// Append the title.
			PdfTitle += Title;

			// Replace slashes.
			PdfTitle = PdfTitle.Replace('/', '-');
			PdfTitle = PdfTitle.Replace('\\', '-');

			// Remove all other invalid characters.
			string invalidCharsRegex = "[" + new string(Path.GetInvalidFileNameChars()) + "]";
			PdfTitle = Regex.Replace(PdfTitle, invalidCharsRegex, "");
		}
	}

}

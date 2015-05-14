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


		private XmlDocument xml;

		public List<Author> Authors { get; private set; }
		public string Title { get; private set; }


		public FB2(string path)
		{
			xml = new XmlDocument();
			xml.Load(path);

			// Add the namespace.
			XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
			ns.AddNamespace("fb", xml.DocumentElement.NamespaceURI);

			Authors = new List<Author>();
			foreach (XmlElement authorXml in xml.SelectNodes("/fb:FictionBook/fb:description/fb:title-info/fb:author", ns))
			{
				Authors.Add(new Author(authorXml));
			}

			XmlNode titleNode = xml.SelectSingleNode("/fb:FictionBook/fb:description/fb:title-info/fb:book-title", ns);
			Title = titleNode != null ? titleNode.InnerText.Trim() : "";
		}
	}

}

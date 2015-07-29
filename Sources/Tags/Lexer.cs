using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KindleLibrarySynchronizer.Tagz
{
	public enum LexemeType
	{
		Character,
		Comma,
		RightBracket,
		LeftBracket,
		RightParenthesis,
		LeftParenthesis,
		IntegerValue,
		FloatValue,
		StringValue,
		Name,
		Function,
	}


	public class Lexeme
	{
		public LexemeType Type { get; private set; }
		public string Value { get; private set; }

		public Lexeme(LexemeType type, string value)
		{
			Type = type;
			Value = value;
		}
	}


	class Lexer : IDisposable, IEnumerable<Lexeme>
	{
		private TextReader reader;
		private bool ownReader = false;


		public Lexer(TextReader reader)
		{
			this.reader = reader;
			ownReader = false;
		}

		public Lexer(Stream stream)
		{
			reader = new StreamReader(stream);
			ownReader = true;
		}

		public Lexer(Stream stream, Encoding encoding)
		{
			reader = new StreamReader(stream, encoding);
			ownReader = true;
		}

		public Lexer(string path)
		{
			reader = new StreamReader(path);
			ownReader = true;
		}

		public Lexer(string path, Encoding encoding)
		{
			reader = new StreamReader(path, encoding);
			ownReader = true;
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (ownReader && reader != null)
				{
					reader.Dispose();
				}
			}
		}

		~Lexer()
		{
			Dispose(false);
		}


		public IEnumerator<Lexeme> GetEnumerator()
		{
			Lexeme lexeme = ReadNextLexeme();

			while (lexeme != null)
			{
				yield return lexeme;
				lexeme = ReadNextLexeme();
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		private Lexeme ReadNextLexeme()
		{
			return null;
		}

	}
}
